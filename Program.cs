using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Start the process
        Process process = new Process();
        process.StartInfo.FileName = "wmic";
        process.StartInfo.Arguments = "diskdrive get model,serialNumber,size,mediaType";

        // Set up output redirection
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;

        // Event handler for when the process writes to its output stream
        process.OutputDataReceived += (sender, e) =>
        {
            Console.WriteLine(e.Data);
        };

        // Event handler for when the process writes to its error stream
        process.ErrorDataReceived += (sender, e) =>
        {
            Console.WriteLine(e.Data);
        };

        // Start the process
        process.Start();

        // Begin asynchronously reading the output streams
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        // Wait for the process to exit
        process.WaitForExit();
    }
}
