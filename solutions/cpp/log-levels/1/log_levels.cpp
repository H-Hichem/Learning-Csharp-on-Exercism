#include <string>

namespace log_line {
std::string message(std::string line) {

    size_t colonPosition = line.find(":");
    std::string message = line.substr(colonPosition+2);

    return message;
}

std::string log_level(std::string line) {
    size_t logLevelStart = line.find("[") +1;
    size_t logLevelEnd = line.find("]");

    size_t logLevelLength = logLevelEnd - logLevelStart;

    std::string logLevel = line.substr(logLevelStart, logLevelLength);

    return logLevel;
}

std::string reformat(std::string line) {
    
    std::string extractedMessage  = message(line);
    std::string logLevel = log_level(line);

    std::string reformatted = extractedMessage + " ("+logLevel+")";
    return reformatted;
}
}  // namespace log_line
