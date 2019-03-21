using System;
using System.IO;


namespace ctpktool
{
    class Program
    {

        public static string InputFile { get; set; }
        public static string InputFileRaw { get; set; }
        public static string InputFolder { get; set; }
        public static string OutputPath { get; set; }

        static int Main(string[] args)
        {
            if (args.Length==0){
                Console.WriteLine("need args");
                return 1;
            }
            string patchPath=null;

            for (int i=0;i<args.Length;i+=2){
                switch(args[i][0]){
                    case 'x':
                        InputFile = args[i+1];
                        break;
                    case 'r':
                        InputFileRaw = args[i+1];
                        break;
                    case 'c':
                        InputFolder = args[i+1];
                        break;
                    case 'o':
                        OutputPath = args[i+1];
                        break;
                    case 'p':
                        patchPath = args[i+1];
                        break;
                    default:
                        Console.WriteLine("Bad argument 0 "+args[i][0]);
                        break;
                }
            }
            

            string inputPath = null, outputPath = null;
            bool isExtract = false, isRawExtract = false, isCreate = false;
            
            if (!String.IsNullOrWhiteSpace(InputFileRaw))
            {
                inputPath = InputFileRaw;
                isRawExtract = true;
                isExtract = true;
            }
            else if (!String.IsNullOrWhiteSpace(InputFile))
            {
                inputPath = InputFile;
                isExtract = true;
            }
            else if (!String.IsNullOrWhiteSpace(InputFolder))
            {
                inputPath = InputFolder;
                isCreate = true;
            }

            if (!String.IsNullOrWhiteSpace(OutputPath))
            {
                outputPath = OutputPath;
            }
            else
            {
                if (isCreate)
                {
                    outputPath = inputPath + ".ctpk";
                }
                else
                {
                    string basePath = Path.GetDirectoryName(inputPath);
                    string baseFilename = Path.GetFileNameWithoutExtension(inputPath);

                    if (!String.IsNullOrWhiteSpace(basePath))
                    {
                        baseFilename = Path.Combine(basePath, baseFilename);
                    }

                    outputPath = baseFilename;
                }
            }
            

            if (isCreate)
            {
                Ctpk.Create(inputPath, outputPath,patchPath);
            }
            else if (isExtract)
            {
                Ctpk.Read(inputPath, outputPath, isRawExtract);
            }
            else
            {
                Console.WriteLine("Could not find path or file '{0}'", args[0]);
            }
            return 0;
        }
    }
}
