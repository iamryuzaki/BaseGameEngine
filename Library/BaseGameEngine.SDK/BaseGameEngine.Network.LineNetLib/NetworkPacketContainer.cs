using System;
using System.IO;
using System.Text;
using BaseGameEngine.SDK.Network;

namespace BaseGameEngine.Network.LineNetLib
{
    public class NetworkPacketContainer : INetworkPacketContainer
    {
        
        private MemoryStream mStream = new MemoryStream();

        public Byte[] Buffer
        {
            get
            {
                if (this.mBuffer == null)
                {
                    this.mBuffer = this.mStream.ToArray();
                }
                return this.mBuffer;
            }
            set
            {
                this.Position = 0;
                this.mStream.Position = 0;
                this.mBuffer = null;
                this.mStream.Write(value, 0, value.Length);
            }
        }

        private Byte[] mBuffer = null;

        public override void Write(float value)
        {
            this.Position += CONST_FloatSize;
            this.mStream.Write(BitConverter.GetBytes(value), 0, CONST_FloatSize);
        }

        public override void Write(bool value)
        {
            this.Write(BitConverter.GetBytes(value));
        }

        public override void Write(byte value)
        {
            this.Position += CONST_ByteSize;
            this.mStream.Write(BitConverter.GetBytes(value), 0, CONST_ByteSize);  
        }

        public override void Write(ushort value)
        {
            this.Position += CONST_Int16Size;
            this.mStream.Write(BitConverter.GetBytes(value), 0, CONST_Int16Size);  
        }

        public override void Write(short value)
        {
            this.Position += CONST_Int16Size;
            this.mStream.Write(BitConverter.GetBytes(value), 0, CONST_Int16Size);  
        }

        public override void Write(int value)
        {
            this.Position += CONST_Int32Size;
            this.mStream.Write(BitConverter.GetBytes(value), 0, CONST_Int32Size);  
        }

        public override void Write(uint value)
        {
            this.Position += CONST_Int32Size;
            this.mStream.Write(BitConverter.GetBytes(value), 0, CONST_Int32Size);  
        }

        public override void Write(long value)
        {
            this.Position += CONST_Int64Size;
            this.mStream.Write(BitConverter.GetBytes(value), 0, CONST_Int64Size);  
        }

        public override void Write(ulong value)
        {
            this.Position += CONST_Int64Size;
            this.mStream.Write(BitConverter.GetBytes(value), 0, CONST_Int64Size);  
        }

        public override void Write(byte[] value)
        {
            this.Write((ushort)value.Length);
            this.mStream.Write(value, 0, value.Length);
            this.Position += (uint)value.Length;
        }

        public override void Write(string value)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(value);
            this.Write(buffer);
        }

        public override bool ReadBool()
        {
            if (this.Position + CONST_ByteSize <= this.Length)
            {
                bool result = BitConverter.ToBoolean(this.Buffer, (int)this.Position);
                this.Position += (uint)CONST_ByteSize;
                return result;
            }
            throw new Exception("This Position + len > this Length");
        }

        public override byte ReadByte()
        {
            if (this.Position + CONST_ByteSize <= this.Length)
            {
                byte result = this.Buffer[this.Position];
                this.Position += (uint)CONST_ByteSize;
                return result;
            }
            throw new Exception("This Position + len > this Length");
        }

        public override float ReadFloat()
        {
            if (this.Position + CONST_FloatSize <= this.Length)
            {
                float result = (float)BitConverter.ToDouble(this.Buffer, (int)this.Position);
                this.Position += (uint)CONST_FloatSize;
                return result;
            }
            throw new Exception("This Position + len > this Length");
        }

        public override short ReadInt16()
        {
            if (this.Position + CONST_Int16Size <= this.Length)
            {
                short result = BitConverter.ToInt16(this.Buffer, (int)this.Position);
                this.Position += (uint)CONST_Int16Size;
                return result;
            }
            throw new Exception("This Position + len > this Length");
        }

        public override ushort ReadUInt16()
        {
            if (this.Position + CONST_Int16Size <= this.Length)
            {
                ushort result = BitConverter.ToUInt16(this.Buffer, (int)this.Position);
                this.Position += (uint)CONST_Int16Size;
                return result;
            }
            throw new Exception("This Position + len > this Length");
        }

        public override int ReadInt32()
        {
            if (this.Position + CONST_Int32Size <= this.Length)
            {
                int result = BitConverter.ToInt32(this.Buffer, (int)this.Position);
                this.Position += (uint)CONST_Int32Size;
                return result;
            }
            throw new Exception("This Position + len > this Length");
        }

        public override uint ReadUInt32()
        {
            if (this.Position + CONST_Int32Size <= this.Length)
            {
                uint result = BitConverter.ToUInt32(this.Buffer, (int)this.Position);
                this.Position += (uint)CONST_Int32Size;
                return result;
            }
            throw new Exception("This Position + len > this Length");
        }

        public override long ReadInt64()
        {
            if (this.Position + CONST_Int64Size <= this.Length)
            {
                long result = BitConverter.ToInt64(this.Buffer, (int)this.Position);
                this.Position += (uint)CONST_Int64Size;
                return result;
            }
            throw new Exception("This Position + len > this Length");
        }

        public override ulong ReadUInt64()
        {
            if (this.Position + CONST_Int64Size <= this.Length)
            {
                ulong result = BitConverter.ToUInt64(this.Buffer, (int)this.Position);
                this.Position += (uint)CONST_Int64Size;
                return result;
            }
            throw new Exception("This Position + len > this Length");
        }

        public override byte[] ReadByteArray()
        {
            ushort len = this.ReadUInt16();
            if (this.Position + len <= this.Length)
            {
                byte[] buffer = new byte[len];
                for (int i = 0; i < len; i++)
                {
                    buffer[i] = this.Buffer[this.Position + i];
                }

                this.Position += len;
                return buffer;
            }
            throw new Exception("This Position + len > this Length");
        }

        public override string ReadString()
        {
            byte[] buffer = this.ReadByteArray();
            this.Position += (uint)buffer.Length;
            return Encoding.Unicode.GetString(buffer);
        }

        public override void Clear()
        {
            this.Position = 0;
            this.mBuffer = null;
            this.mStream.Position = 0;
        }

        protected override void IncomingBuffer(byte[] buffer)
        {
            this.mBuffer = buffer;
        }
    }
}