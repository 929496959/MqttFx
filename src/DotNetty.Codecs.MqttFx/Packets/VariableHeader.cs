﻿using DotNetty.Buffers;

namespace DotNetty.Codecs.MqttFx.Packets
{
    /// <summary>
    /// 可变报头(Variable header)
    /// </summary>
    public abstract class VariableHeader
    {
        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="buffer"></param>
        public virtual void Encode(IByteBuffer buffer) { }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="remainingLength"></param>
        public virtual void Decode(IByteBuffer buffer, ref int remainingLength) { }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="fixedHeader"></param>
        public void Decode(IByteBuffer buffer, FixedHeader fixedHeader)
        {
            int remainingLength = fixedHeader.RemaingLength;
            Decode(buffer, ref remainingLength);
            fixedHeader.RemaingLength = remainingLength;
        }
    }
}