using System;
using System.Text;
using System.IO;

namespace BitSquish
{
	public class BinaryIO
	{
		/// <summary>
		/// Binary IO is responsible for writing and reading binary files.
		/// </summary>
		public class Input
		{
			/// <summary>
			/// Gets the binary string after initialization
			/// </summary>
			/// <value>The binary string</value>
			public string BinaryString { get; private set; }

			/// <summary>
			/// Gets or sets the filename
			/// </summary>
			/// <value>The filename</value>
			string Filename { get; set; }

			/// <summary>
			/// Initializes a new instance of the <see cref="BitSquish.BinaryIO"/> class.
			/// This will read the binary from the filename and assign the binary string to it.
			/// </summary>
			/// <param name="filename">Filename.</param>
			public Input (string filename)
			{
				BinaryString = "";
				Filename = filename;

				StringBuilder sb = new StringBuilder();
				foreach(byte b in File.ReadAllBytes(filename))
				{
					
					sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));  

				}

				BinaryString = sb.ToString();
			}
		}
	}
}

