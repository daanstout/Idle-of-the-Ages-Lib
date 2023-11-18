namespace IdleOfTheAgesLib.Saving {
    internal interface ISaveWriter {
        bool WriteInt();
        bool WriteUint();
        bool WriteByte();
        bool WriteSByte();
        bool WriteShort();
        bool WriteUshort();
        bool WriteLong();
        bool WriteULong();
        bool WriteChar();
        bool WriteString(int length);
    }
}
