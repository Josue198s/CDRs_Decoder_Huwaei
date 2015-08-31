using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DescodificaCDRs;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
//using System.IO.FileInfo;

namespace ConsoleApplication1
{

    class Program
    {

     
/**
        static void Main(string[] args)
        {
           
          //  run(args);
        }

   **/
        public static string[] data = null;
        public static string myString=null;
        public static string new_file=null;

        static void Main(string[] args)
        {
            run(args);// points here
        }
    

        static void  run(string[] args)
        {

            int myl = args.Length;
         //   Console.Write(myl+ " The lenght of the file");
            int fileleg = 0;
            string myString = null;
             string txtfile = null;
             string final_path = null;
            for (int i = 0; i < args.Length; i++)
            {
             //   Console.WriteLine(args[i]+"\n");// this the file being showed on the console
                fileleg = args[i].Length;// the lenght of the file
                string dstring=args[i];// putting the file on the dstring
                new_file = args[i].Replace(".dat", ".txt");// taking the name of the file dat and naming it txt
             //   Console.WriteLine(new_file + "\n");// show the file in txt extension
                System.IO.StreamReader myFile = new System.IO.StreamReader(args[i]);// reading the dat file in the myString
                myString = myFile.ReadToEnd();// readin it to the end of file
                myFile.Close();//closing file
          
                
           //     Console.WriteLine("Done reading the dat file.\n ");
                WriteFile("",new_file);//The takes the and the write to the newfile in txt formart and adding null string.
          //      Console.Write("Done reading the dat file.\n "); //done writting the txt file
              //  Console.WriteLine(args[i]+"\t Showing the dat file\n");
                txtfile=new_file;
            //    Console.WriteLine(txtfile+ "\t this the file for the path \n");
                final_path = Path.Combine(Environment.CurrentDirectory, @"Data\", args[i]);
           //     Console.WriteLine(final_path + "\t this the complete path of the file");
            //    Console.WriteLine("\n\n");

                carregarRegisto(args[i]);
                //  Console.WriteLine(myString);
                //  Display the file contents.
                // Console.WriteLine(myString);
                // Suspend the screen.
                // Console.ReadLine();
   
            }

        }

        static string getfile(string file)
        {
            return file; 
        }

        static void  WriteFile(string text, string path)
        {
         //   Console.WriteLine("I am here \n");
            System.IO.StreamWriter file = new System.IO.StreamWriter(path,true);
            file.WriteLine(text);
            file.Close();
        }

        static void carregarRegisto(string ficheiro)
        {
    //        Console.Write("I am here Car in method 1 \n ");
            string txtfile = getfile(new_file);
            byte[] array = null;
         //   bool flag = false;
            DecCDRs rs = new DecCDRs();
            FileStream input = null;
            Collection collection3 = new Collection();
            Collection collection = new Collection();
            Collection collection2 = new Collection();
            Array.Resize<byte>(ref array, 0x22a);
            string path = ficheiro;
           // Console.Write("this is the  Path -->"+path);
            input = File.OpenRead(path);
           // Console.Write("1 -->");
            BinaryReader reader = new BinaryReader(input);
            //Console.Write("2 -->");
            long length = input.Length;
            if ((length % 0x22aL) != 0L)
            {
                Console.Write("3 -->");
            }
            MemoryStream stream2 = new MemoryStream(reader.ReadBytes(Convert.ToInt32(length)));
            int num5 = Convert.ToInt32((double)(((double)length) / 554.0));
            int num6 = num5;
            for (int i = 1; i <= num6; i++)
            {
                REG_Detail detail = new REG_Detail();
                stream2.Read(array, 0, 0x22a);
                Array.Resize<byte>(ref array, 0x22a);
                rs.Registo = array;
                REG_Detail detail2 = detail;
                detail2.Csn = Conversions.ToLong(rs.decIntg(0, 4, "L"));
                detail2.Length = Conversions.ToShort(rs.decIntg(4, 2, "L"));
                detail2.Net_Type = Conversions.ToShort(rs.decIntg(6, 1, "L"));
                detail2.Bill_Type = rs.decIntg(7, 1, "S");
                detail2.Ans_Time = rs.decIntg(11, 6, "T");
                detail2.End_Time = rs.decIntg(0x11, 6, "T");
                detail2.Conversation_Time = Conversions.ToDouble(rs.decIntg(0x17, 4, "L"));
                detail2.Caller_Address_Nature = Conversions.ToShort(rs.decIntg(0x1d, 1, "L"));
                detail2.Caller_Number = rs.decIntg(30, 10, "D");
                detail2.Called_Address_Nature = Conversions.ToShort(rs.decIntg(0x2a, 1, "L"));
                detail2.Called_Number = rs.decIntg(0x2b, 10, "D");
                detail2.Tunk_Group_In = Conversions.ToLong(rs.decIntg(0x41, 2, "L"));
                detail2.Tunk_Group_Out = Conversions.ToLong(rs.decIntg(0x43, 2, "L"));
                detail2.Termination_Cod = Conversions.ToInteger(rs.decIntg(0x4a, 1, "L"));
                detail2.Dial_Number = rs.decIntg(0x7d, 0x10, "D");
                string now = "CDR_CSN=" + detail2.Csn.ToString() + " " + "CDR_LENGHT=" + detail2.Length.ToString()
                    +" "+ "CDR_NET_TYPE=" +detail2.Net_Type.ToString() + " " + "CDR_BILL_TYPE=" + detail2.Bill_Type.ToString()
                    + " " + "CDR_ANS_TIME=" + detail2.Ans_Time.ToString() + " " + "CDR_END_TIME=" + detail2.End_Time.ToString()
                    + " " + "CDR_CONVERSATION_TYPE=" + detail2.Conversation_Time.ToString() + " " + "CDR_CALLER_AD=" +
                    detail2.Caller_Address_Nature.ToString() + " " + "CDR_CALLER_NUMBER=" + detail2.Caller_Number.ToString()+" "
                    + "CDR_CALLER_ADDRESS_NATURE=" + detail2.Called_Address_Nature.ToString() + " "
                    + "CDR_CALLER_NUMBER=" + detail2.Called_Number.ToString() +
                    " " + "CDR_TRUNK_GROUP_IN=" + detail2.Tunk_Group_In.ToString() + " " + "CDR_TRUNK_GROUP_OUT="
                    + detail2.Tunk_Group_Out.ToString() + " " + "CDR_TERMINATION_COD=" + detail2.Termination_Cod.ToString()
                    + " " + "DIAL_NUMBER=" +
                    detail2.Dial_Number.ToString();
           //     Console.Write("We Writing");
                WriteFile(now, new_file);

             //   detail2 = null;
            }
           
        }

            
    }

    public class REG_Detail
    {
        private string mAns_Time;
        private string mBill_Type;
        private short mCalled_Address_Nature;
        private string mCalled_Number;
        private short mCaller_Address_Nature;
        private string mCaller_Number;
        private double mConversation_Time;
        private long mCsn;
        private string mDial_Number;
        private string mEnd_time;
        private short mLength;
        private short mNet_Type;
        private int mTermination_Cod;
        private long mTrunk_Group_In;
        private long mTrunk_Group_Out;

        public string Ans_Time
        {
            get
            {
                return this.mAns_Time;
            }
            set
            {
                this.mAns_Time = value;
            }
        }

        public string Bill_Type
        {
            get
            {
                return this.mBill_Type;
            }
            set
            {
                this.mBill_Type = value;
            }
        }

        public short Called_Address_Nature
        {
            get
            {
                return this.mCalled_Address_Nature;
            }
            set
            {
                this.mCalled_Address_Nature = value;
            }
        }

        public string Called_Number
        {
            get
            {
                return this.mCalled_Number;
            }
            set
            {
                this.mCalled_Number = value;
            }
        }

        public short Caller_Address_Nature
        {
            get
            {
                return this.mCaller_Address_Nature;
            }
            set
            {
                this.mCaller_Address_Nature = value;
            }
        }

        public string Caller_Number
        {
            get
            {
                return this.mCaller_Number;
            }
            set
            {
                this.mCaller_Number = value;
            }
        }

        public double Conversation_Time
        {
            get
            {
                return this.mConversation_Time;
            }
            set
            {
                this.mConversation_Time = value / 100.0;
            }
        }

        public long Csn
        {
            get
            {
                return this.mCsn;
            }
            set
            {
                this.mCsn = value;
            }
        }

        public string Dial_Number
        {
            get
            {
                return this.mDial_Number;
            }
            set
            {
                this.mDial_Number = value;
            }
        }

        public string End_Time
        {
            get
            {
                return this.mEnd_time;
            }
            set
            {
                this.mEnd_time = value;
            }
        }

        public short Length
        {
            get
            {
                return this.mLength;
            }
            set
            {
                this.mLength = value;
            }
        }

        public short Net_Type
        {
            get
            {
                return this.mNet_Type;
            }
            set
            {
                this.mNet_Type = value;
            }
        }

        public int Termination_Cod
        {
            get
            {
                return this.mTermination_Cod;
            }
            set
            {
                this.mTermination_Cod = value;
            }
        }

        public long Tunk_Group_In
        {
            get
            {
                return this.mTrunk_Group_In;
            }
            set
            {
                this.mTrunk_Group_In = value;
            }
        }

        public long Tunk_Group_Out
        {
            get
            {
                return this.mTrunk_Group_Out;
            }
            set
            {
                this.mTrunk_Group_Out = value;
            }
        }
    }
    
}
