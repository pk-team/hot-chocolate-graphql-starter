namespace App.Service;

public class Error {

    public string Message { get; set; } = "";
    public List<string> Paths { get; set; } = new List<string>();
}
