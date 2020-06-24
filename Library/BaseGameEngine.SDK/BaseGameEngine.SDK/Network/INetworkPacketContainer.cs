using System;
using System.Collections;
using System.Collections.Generic;
using SharpDX.Direct2D1;

namespace BaseGameEngine.SDK.Network
{
    public class INetworkPacketContainer
    {
        protected const byte CONST_FloatSize = 4;
        protected const byte CONST_Int32Size = 4;
        protected const byte CONST_Int16Size = 2;
        protected const byte CONST_Int64Size = 8;
        protected const byte CONST_ByteSize = 1;

        private static Stack<INetworkPacketContainer> PoolContainers { get; } = new Stack<INetworkPacketContainer>();

        public static T GetPacketContainer<T>(byte[] buffer = null) where T : INetworkPacketContainer
        {
            T container = null;
            lock (PoolContainers)
            {
                if (PoolContainers.Count > 0)
                {
                    container = (T)PoolContainers.Pop();
                }
                else
                {
                    container = (T)Activator.CreateInstance(typeof(T), true);
                }
            }

            if (buffer != null)
            {
                container.IncomingBuffer(buffer);
            }
            return container;
        }
        
        public static void FreePacketContainer(ref INetworkPacketContainer container)
        {
            container.Clear();
            lock (PoolContainers)
            {
                PoolContainers.Push(container);
            }
        }

        public Byte[] Buffer { get; set; }
        public UInt32 Position { get; set; }
        public UInt32 Length => (UInt32)this.Buffer.Length;

        public virtual void Clear()
        {
            
        }
        
        protected virtual void IncomingBuffer(byte[] buffer)
        {
            
        }
        
        public virtual void Write(float value)
        {
            
        }
        
        public virtual void Write(byte value)
        {
            
        }
        
        public virtual void Write(byte[] value)
        {
            
        }
        
        public virtual void Write(bool value)
        {
            
        }
        
        public virtual void Write(short value)
        {
            
        }
        
        public virtual void Write(ushort value)
        {
            
        }
        
        public virtual void Write(int value)
        {
            
        }
        
        public virtual void Write(uint value)
        {
            
        }
        
        public virtual void Write(long value)
        {
            
        }
        
        public virtual void Write(ulong value)
        {
            
        }
        
        public virtual void Write(string value)
        {
            
        }

        public virtual float ReadFloat()
        {
            return 0f;
        }
        
        public virtual byte ReadByte()
        {
            return 0;
        }
        
        public virtual byte[] ReadByteArray()
        {
            return null;
        }
        
        public virtual bool ReadBool()
        {
            return false;
        }
        
        public virtual short ReadInt16()
        {
            return 0;
        }
        
        public virtual ushort ReadUInt16()
        {
            return 0;
        }
        
        public virtual int ReadInt32()
        {
            return 0;
        }
        
        public virtual uint ReadUInt32()
        {
            return 0;
        }
        
        public virtual ulong ReadUInt64()
        {
            return 0;
        }
        
        public virtual long ReadInt64()
        {
            return 0;
        }
        
        public virtual string ReadString()
        {
            return string.Empty;
        }
    }
}