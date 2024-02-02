namespace ConsoleArchivist.Exceptions;

public class ContentNullException(string paramName, string message) 
    : Exception($"{paramName}: {message}") { }

public class EmptyContentException(string paramName, string message) 
    : Exception($"{paramName}: {message}") { }

public class KeyAbsentException(string paramName, string message) 
    : Exception($"{paramName}: {message}") { }