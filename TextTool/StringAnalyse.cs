using System;
using System.Text;
using System.Collections;

namespace TextTool
{
	/// <summary>
	/// ������Ӧ�����ַ����ֽ�����ɵ��ʡ�
	/// </summary>
	public class StringAnalyse
	{
		/// <summary>
		/// ��ŵ��ʵ�����
		/// </summary>
		private string[] tokens;

		/// <summary>
		/// �ֽ��Ե�һ�ַ����ָ��������ɵ���
		/// </summary>
		/// <param name="dataLine">���������ַ���</param>
		/// <param name="delimiter">�ָ���</param>
		public void Analyse(string dataLine,string delimiter)
		{
			dataLine = dataLine.Trim();
			ArrayList temp = new ArrayList();
			int index;
			while ((index = dataLine.IndexOf(delimiter)) != -1)
			{
				temp.Add(dataLine.Substring(0, index));
				dataLine = dataLine.Substring(index + 1).Trim();
			}
			temp.Add(dataLine);
			tokens = new string[temp.Count];
			for (int i = 0; i < tokens.Length; i++)
			{
				tokens[i] = temp[i].ToString() ;
			}
		}

		/// <summary>
		/// �ֽ����ַ�������ָ��������ɵ���
		/// </summary>
		/// <param name="dataLine">���������ַ���</param>
		/// <param name="delimiters">�ָ�������</param>
		public void Analyse(string dataLine, string[] delimiters)
		{
			dataLine.Trim();
			tokens = new string[delimiters.Length + 1];

			for (int i = 0; i < delimiters.Length; i++)
			{
				int delimiterIndex = dataLine.IndexOf(delimiters[i]);
				tokens[i] = dataLine.Substring(0,delimiterIndex);
				tokens[i].Trim();
				dataLine = dataLine.Substring(delimiterIndex + 1);
			}
			tokens[delimiters.Length] = dataLine;
		}

		/// <summary>
		/// �ֽ�ָ����ʼ����λ�õ����ɵ���
		/// </summary>
		/// <param name="startIndex">���ʵ���ʼλ��</param>
		/// <param name="endIndex">���ʵĽ���λ��</param>
		public void Analyse(string dataLine, int[] startIndex,int[] endIndex)
		{
			tokens = new string[startIndex.Length];
			int length = dataLine.Length;
			for (int i = 0; i < startIndex.Length; i++)
			{
				if (endIndex[i] <= length )
				{
					tokens[i] = dataLine.Substring(startIndex[i], endIndex[i] - startIndex[i]);
					tokens[i] = tokens[i].Trim();
				}                
			}
		}
		/// <summary>
		/// �ֽ�ָ����ʼ����λ�õĵ�����
		/// </summary>
		/// <param name="dataLine">��Ҫ�������ַ���</param>
		/// <param name="startIndex">��ʼλ��</param>
		/// <param name="endIndex">����λ��</param>
		/// <returns>��ȡ���</returns>
		public string Analyse(string dataLine, int startIndex,int endIndex)
		{
			string result = "";
			int length = dataLine.Length;
			if (endIndex <= length )
			{
				result = dataLine.Substring(startIndex, endIndex - startIndex);
			}
			return result;
		}

		/// <summary>
		/// ��ȡĳ������λ�õĵ���
		/// </summary>
		/// <param name="index">����λ�ã���0��ʼ</param>
		/// <returns>����λ�ö�Ӧ�ĵ���</returns>
		public string GetElementAt(int index)
		{
			if (index < tokens.Length)
			{
				return tokens[index];
			}
			else
			{
				return null;
			}
		}
        
		/// <summary>
		/// ��ȡ���������ĵ�������
		/// </summary>
		public int Length
		{
			get 
			{
				if (tokens == null)
				{
					return 0;
				}
				else
				{
					return tokens.Length;
				}                 
			}
		}

	}
}
