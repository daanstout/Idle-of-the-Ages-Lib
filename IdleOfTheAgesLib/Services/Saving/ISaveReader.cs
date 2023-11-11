namespace IdleOfTheAgesLib.Services.Saving {
    internal interface ISaveReader {
        int ReadInt();
        uint ReadUint();
        byte ReadByte();
        sbyte ReadSByte();
        short ReadShort();
        ushort ReadUshort();
        long ReadLong();
        ulong ReadULong();
        char ReadChar();
        string ReadString(int length);
    }
}
