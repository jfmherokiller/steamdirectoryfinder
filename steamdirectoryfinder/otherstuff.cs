﻿using System;
using System.IO;
using System.Text;

namespace steamdirectoryfinder
{
    internal class ConsoleCopy : IDisposable
    {
        private readonly TextWriter _oldOut;
        private TextWriter _doubleWriter;
        private FileStream _fileStream;
        private StreamWriter _fileWriter;

        public ConsoleCopy(string path)
        {
            _oldOut = Console.Out;

            try
            {
                _fileStream = File.Create(path);

                _fileWriter = new StreamWriter(_fileStream) { AutoFlush = true };

                _doubleWriter = new DoubleWriter(_fileWriter, _oldOut);
            }
            catch (Exception e)
            {
                Console.WriteLine(@"Cannot open file for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(_doubleWriter);
        }

        public void Dispose()
        {
            Console.SetOut(_oldOut);
            if (_doubleWriter != null)
            {
                _doubleWriter.Flush();
                _doubleWriter.Close();
                _doubleWriter = null;
            }
            if (_fileWriter != null)
            {
                _fileWriter.Flush();
                _fileWriter.Close();
                _fileWriter = null;
            }
            if (_fileStream != null)
            {
                _fileStream.Close();
                _fileStream = null;
            }
        }

        private class DoubleWriter : TextWriter
        {
            private readonly TextWriter _one;
            private readonly TextWriter _two;

            public DoubleWriter(TextWriter one, TextWriter two)
            {
                _one = one;
                _two = two;
            }

            public override Encoding Encoding
            {
                get { return _one.Encoding; }
            }

            public override void Flush()
            {
                _one.Flush();
                _two.Flush();
            }

            public override void Write(char value)
            {
                _one.Write(value);
                _two.Write(value);
            }
        }
    }
}