﻿using ExternalFiles.Readers;

namespace MladostAir.Client
{
    public class Startup
    {
        public static void Main()
        {
            JsonReportFileReader.ReadJsonFile();
        }
    }
}
