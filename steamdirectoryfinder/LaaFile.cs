using System;
using System.IO;

namespace steamdirectoryfinder
{
    public class LaaFile
    {
        private readonly string _path;
        private Characteristics _characteristics;
        private long _characteristicsOffset = -1L;
        public LaaFile(string path)
        {
            _path = path;
            ReadCharacteristics();
        }

        public bool LargeAddressAware
        {
            get
            {
                return (_characteristics & Characteristics.ImageFileLargeAddressAware) == Characteristics.ImageFileLargeAddressAware;
            }
        }
        public bool WriteCharacteristics(bool laa)
        {
            var characteristics = _characteristics;
            return WriteCharacteristics(!laa ? ~Characteristics.ImageFileLargeAddressAware & characteristics : Characteristics.ImageFileLargeAddressAware | characteristics);
        }

        private bool GetOffsets()
        {
            bool flag = true;
            try
            {
                FileStream fileStream = new FileStream(_path, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)fileStream);
                fileStream.Seek(0L, SeekOrigin.Begin);
                if ((int)binaryReader.ReadByte() != 77)
                    throw new Exception();
                if ((int)binaryReader.ReadByte() != 90)
                    throw new Exception();
                fileStream.Seek(60L, SeekOrigin.Begin);
                long offset = (long)binaryReader.ReadUInt32();
                fileStream.Seek(offset, SeekOrigin.Begin);
                if ((int)binaryReader.ReadByte() != 80)
                    throw new Exception();
                if ((int)binaryReader.ReadByte() != 69)
                    throw new Exception();
                fileStream.Seek(20L, SeekOrigin.Current);
                _characteristicsOffset = fileStream.Position;
                _characteristics = (Characteristics)binaryReader.ReadUInt16();
                binaryReader.Close();
                fileStream.Close();
            }
            catch
            {
                _characteristicsOffset = -1L;
                flag = false;
            }
            return flag;
        }

        private bool ReadCharacteristics()
        {
            if (_characteristicsOffset == -1L)
                return GetOffsets();
            bool flag = true;
            try
            {
                FileStream fileStream = new FileStream(_path, FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader((Stream)fileStream);
                fileStream.Seek(_characteristicsOffset, SeekOrigin.Begin);
                _characteristics = (Characteristics)binaryReader.ReadUInt16();
                binaryReader.Close();
                fileStream.Close();
            }
            catch
            {
                _characteristicsOffset = -1L;
                flag = false;
            }
            return flag;
        }

        private bool WriteCharacteristics(Characteristics value)
        {
            if (_characteristicsOffset == -1L)
                return false;
            bool flag = true;
            try
            {
                FileStream fileStream = new FileStream(_path, FileMode.Open, FileAccess.Write);
                BinaryWriter binaryWriter = new BinaryWriter((Stream)fileStream);
                fileStream.Seek(_characteristicsOffset, SeekOrigin.Begin);
                binaryWriter.Write((ushort)value);
                binaryWriter.Flush();
                binaryWriter.Close();
                fileStream.Close();
                _characteristics = value;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
    }
}