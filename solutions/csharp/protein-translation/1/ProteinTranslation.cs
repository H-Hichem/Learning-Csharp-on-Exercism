public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        if (strand.Length < 3) return Array.Empty<string>();

        var codonMap = new Dictionary<string, string>
            {{ "AUG", "Methionine" },
            { "UUU", "Phenylalanine" },
            { "UUC", "Phenylalanine" },
            { "UUA", "Leucine" },
            { "UUG", "Leucine" },
            { "UCU", "Serine" },
            { "UCC", "Serine" },
            { "UCA", "Serine" },
            { "UCG", "Serine" },
            { "UAU", "Tyrosine" },
            { "UAC", "Tyrosine" },
            { "UGU", "Cysteine" },
            { "UGC", "Cysteine" },
            { "UGG", "Tryptophan" }};
            
        var stopCodons = new HashSet<string> { "UAA", "UAG", "UGA" };
        
        var codons = strand.ToCharArray().Chunk(3)               
            .Select(chars => new string(chars)) 
            .ToList();
        var proteins = new List<string>();

        foreach (var codon in codons)
        {
            if (stopCodons.Contains(codon)) break;
            if (codonMap.TryGetValue(codon, out var protein)){proteins.Add(protein);}
        }

        return proteins.ToArray();
    }
}