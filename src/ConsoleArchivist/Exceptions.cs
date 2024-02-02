namespace ConsoleArchivist.Exceptions;

public class ContentNullException(string paramName, string message) 
    : Exception($"{paramName}: {message}") { }

public class EmptyContentException(string paramName, string message) 
    : Exception($"{paramName}: {message}") { }

public class LagTagAbsentException(string paramName, string message) 
    : Exception($"{paramName}: {message}") { }