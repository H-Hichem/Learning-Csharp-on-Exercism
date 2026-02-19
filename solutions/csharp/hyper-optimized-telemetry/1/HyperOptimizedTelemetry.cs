public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long value)
    {
        byte[] buffer = new byte[9]; 
        int payloadBytes;
        bool signed;

        // -------- type selection --------
        if (value >= 0)
        {
            if (value <= ushort.MaxValue)
            {
                payloadBytes = 2;
                signed = false;
            }
            else if (value <= int.MaxValue)
            {
                payloadBytes = 4;
                signed = true;
            }
            else if (value <= uint.MaxValue)
            {
                payloadBytes = 4;
                signed = false;
            }
            else
            {
                payloadBytes = 8;
                signed = true;
            }
        }
        else
        {
            signed = true;
            if (value >= short.MinValue) payloadBytes = 2;
            else if (value >= int.MinValue) payloadBytes = 4;
            else payloadBytes = 8;
        }

        // -------- prefix --------

        buffer[0] = signed
            ? (byte)(256 - payloadBytes)
            : (byte)payloadBytes;

        // -------- payload (little endian) --------

        byte[] bytes;

        if (payloadBytes == 2)
            bytes = BitConverter.GetBytes((short)value);
        else if (payloadBytes == 4)
            bytes = signed
                ? BitConverter.GetBytes((int)value)
                : BitConverter.GetBytes((uint)value);
        else
            bytes = BitConverter.GetBytes(value);

        Array.Copy(bytes, 0, buffer, 1, payloadBytes);
        
        return buffer; 
    }

    
    public static long FromBuffer(byte[] buffer)
    {
        if (buffer == null || buffer.Length < 1)
            return 0;

        byte prefix = buffer[0];
        bool signed;
        int payloadBytes;

        // Determine signedness and payload bytes from prefix
        if (prefix == 2 || prefix == 4 || prefix == 8)
        {
            signed = false;
            payloadBytes = prefix;
        }
        else if (prefix == 254 || prefix == 252 || prefix == 248)
        {
            signed = true;
            payloadBytes = 256 - prefix; // invert signed prefix
        }
        else
        {
            // Invalid prefix
            return 0;
        }

        // Make sure buffer has enough bytes
        if (buffer.Length < 1 + payloadBytes)
            return 0;

        long value;

        switch (payloadBytes)
        {
            case 2:
                value = signed
                    ? BitConverter.ToInt16(buffer, 1)
                    : BitConverter.ToUInt16(buffer, 1);
                break;
            case 4:
                value = signed
                    ? BitConverter.ToInt32(buffer, 1)
                    : BitConverter.ToUInt32(buffer, 1);
                break;
            case 8:
                value = BitConverter.ToInt64(buffer, 1); // long is always signed
                break;
            default:
                value = 0; // should not happen
                break;
        }

        return value;
    }
}
