namespace DescodificaCDRs
{
    
    using Microsoft.VisualBasic;
    using System;
    using System.Globalization;
    using Microsoft.VisualBasic.CompilerServices;


    public class DecCDRs
    {

        private int ind;
        private byte[] mregisto;

        public string decIntg(short Inicio, short Tamanho, string Tipo)
        {


            byte[] mbocado = null;
            string str = null;
            if (Tamanho > 1)
            {
                Array.Resize<byte>(ref mbocado, Tamanho);
            }
            else
            {
                Array.Resize<byte>(ref mbocado, 1);
            }
            int VBt_i4L0 = Tamanho - 1;
            this.ind = 0;
            while (this.ind <= VBt_i4L0)
            {
                mbocado[this.ind] = this.mregisto[Inicio + this.ind];
                this.ind++;
            }
            switch (Tipo)
            {
                case "L":
                    {
                        Array.Reverse(mbocado);
                        str = "&H";
                        int VBt_i4L1 = Tamanho - 1;
                        this.ind = 0;
                        while (this.ind <= VBt_i4L1)
                        {
                            str = str + Conversion.Hex(mbocado[this.ind]);
                            this.ind++;
                        }
                        string nowd = Conversions.ToLong(str).ToString();//Josue 
              //          showupl(nowd);//Josue  Here we get the CDR_CSN,CDR_LENGTH and CDR_NET_TYPE 
                        //After the T CDR_CONVERSATION,CDR CALLER AD
                        return nowd;//Josue 
                        // return Conversions.ToLong(str).ToString();
                    }
                case "T":
                    {
                        str = "20";
                        int VBt_i4L2 = Tamanho - 1;
                        this.ind = 0;
                        while (this.ind <= VBt_i4L2)
                        {
                            str = str + mbocado[this.ind].ToString().PadLeft(2, '0');
                            this.ind++;
                        }
               //         showupt(str);//Josue CDR_ANS_TYP,CDR_END_TYP
                        return str;
                    }
                case "D":
                    {
                        str = "";
                        int VBt_i4L3 = Tamanho - 1;
                        this.ind = 0;
                        while (this.ind <= VBt_i4L3)
                        {
                            str = str + Conversion.Hex(mbocado[this.ind]).ToString().PadLeft(2, '0');
                            this.ind++;
                        }
                        string now = str.Replace('F', ' ').Trim();//Josue 

               //         showupd(now);//Josue CDR_TYPE_BILL. AFTER L CDR CALLED_AD
                        return now;//Josue 
                        // return str.Replace('F', ' ').Trim();
                    }
                case "S":
                    {
                        str = "";
                        int VBt_i4L4 = Tamanho - 1;
                        this.ind = 0;
                        while (this.ind <= VBt_i4L4)
                        {
                            str = str + Conversion.Hex(mbocado[this.ind]).ToString().PadLeft(2, '0');
                            this.ind++;
                        }
            //            showups(str);//Josue Stuff
                        return str;
                    }
            }
            return "";
        }

        public byte[] Registo
        {
            set
            {

                this.mregisto = value;


            }
        }


        //Josue Stuff
        public void showups(string r)
        {
            // for (int i = 0; i < r.Length; i++)
            //   {
            //  string result = ToString(" "+r[i]);
          Console.WriteLine("i am Here D this is the string --> " + r);
            //   }
        }

        public void showupd(string r)
        {
            // for (int i = 0; i < r.Length; i++)
            //   {
            //  string result = ToString(" "+r[i]);
            Console.WriteLine("i am Here D this is the string --> " + r);
            //   }
        }

        public void showupt(string r)
        {
            // for (int i = 0; i < r.Length; i++)
            //   {
            //  string result = ToString(" "+r[i]);
            Console.WriteLine("i am Here T this is the string --> " + r);
            //   }
        }

        public void showupl(string r)
        {
            // for (int i = 0; i < r.Length; i++)
            //   {
            //  string result = ToString(" "+r[i]);
            Console.WriteLine("i am Here L this is the string --> " + r);
            //   }
        }
    }
}

