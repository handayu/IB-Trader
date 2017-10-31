using System;
using System.Collections;
using System.IO;

namespace TextTool
{
	/// <summary>
	/// �ṩ����ı��ļ��Ĵ�����
	/// </summary>
	public class TextFile
	{
		/// <summary>
		/// ���ڴ洢Text�ļ��е�StringAnalyse����
		/// </summary>
		private ArrayList textList;

		/// <summary>
		/// �ָ���
		/// </summary>
		private string delimiter;
        
		private float maxFieldNum;
		/// <summary>
		/// ���ϵ�����ֶ���
		/// </summary>
		public float MaxFieldNum
		{
			get { return maxFieldNum; }
		}


		/// <summary>
		/// ʵ����Text�ļ��������
		/// </summary>
		public TextFile(string delimiter)
		{
			textList = new ArrayList();
			this.delimiter = delimiter;
            
		}

		/// <summary>
		/// ���ļ�
		/// </summary>
		/// <param name="fileName"></param>
		public void OpenFile(string fileName)
		{
			textList.Clear();
			maxFieldNum = 0;

			using (StreamReader sr = new StreamReader(fileName,System.Text.Encoding.GetEncoding("gb2312")))
			{
				//1:sr.ReadToEnd();����split('\n')�ڸ��ֿ�
				//2:sr.Read (Char[], Int32, Int32) 
				
				string line = "";

				if (delimiter != "")
					while ((line = sr.ReadLine()) != null)
					{
						StringAnalyse stringAnalyse = new StringAnalyse();
						stringAnalyse.Analyse(line, delimiter);
						textList.Add(stringAnalyse);
						if (maxFieldNum < stringAnalyse.Length)
						{
							maxFieldNum = stringAnalyse.Length;
						}
					}
				else
				{
					while ((line = sr.ReadLine()) != null)
					{
						int[] start = new int[]{0};
						int[] end = new int[]{line.Length - 1};
						StringAnalyse stringAnalyse = new StringAnalyse();
						stringAnalyse.Analyse(line, start, end);
						textList.Add(stringAnalyse);
						if (maxFieldNum < stringAnalyse.Length)
						{
							maxFieldNum = stringAnalyse.Length;
						}
					}
				}
			}
		}

		/// <summary>
		/// ��ȡλ��ĳ�е�StringAnalyse����
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public StringAnalyse GetElementAt(int index)
		{
			return (StringAnalyse)textList[index];
		}

		/// <summary>
		/// ��ȡ���е�StringAnalyse����
		/// </summary>
		/// <returns></returns>
		public ArrayList GetAllTextList()
		{
			return textList;
		}

		/// <summary>
		/// ���SPS�ļ�
		/// </summary>
		public void Clear()
		{
			textList.Clear();
			maxFieldNum = 0;
		}

		/// <summary>
		/// ��ȡLVL�ļ���LVL���ݵ��ܳ���
		/// </summary>
		public int Count
		{
			get
			{
				return textList.Count;
			}
		}
	}
}
