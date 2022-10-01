﻿using AssetRipper.IO.Endian;

namespace AssetRipper.IO.Files.BundleFiles.FileStream
{
	public sealed record class FileStreamNode : Node
	{
		public override void Read(EndianReader reader)
		{
			Offset = reader.ReadInt64();
			Size = reader.ReadInt64();
			Flags = (NodeFlags)reader.ReadInt32();
			Path = reader.ReadStringZeroTerm();
		}

		public override void Write(EndianWriter writer)
		{
			writer.Write(Offset);
			writer.Write(Size);
			writer.Write((int)Flags);
			writer.WriteStringZeroTerm(Path);
		}

		public NodeFlags Flags { get; set; }
	}
}
