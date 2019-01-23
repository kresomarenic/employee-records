using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencijaZaposlenika
{
    class Zaposlenik
    {
        string ime;
        string prezime;
        string oib;
        string nazivRadnogMjesta;
        DateTime datumZaposlenja;
        DateTime datumPrekidaZaposlenja;

        public Zaposlenik(string ime, string prezime, string oib, string nazivRadnogMjesta, DateTime datumZaposlenja)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.oib = oib;
            this.nazivRadnogMjesta = nazivRadnogMjesta;
            this.datumZaposlenja = datumZaposlenja;
        }

        public string getIme()
        {
            return this.ime;
        }

        public void setIme(string ime)
        {
            this.ime = ime;
        }

        public string getPrezime()
        {
            return this.prezime;
        }

        public void setPrezime(string prezime)
        {
            this.prezime = prezime;
        }
        public string getOIB()
        {
            return this.oib;
        }

        public void setOIB(string oib)
        {
            this.oib = oib;
        }
        public string getNazivRadnogMjesta()
        {
            return this.nazivRadnogMjesta;
        }

        public void setNazivRadnogMjesta(string nazivRadnogMjesta)
        {
            this.nazivRadnogMjesta = nazivRadnogMjesta;
        }
        public DateTime getDatumZaposlenja()
        {
            return this.datumZaposlenja;
        }

        public void setDatumZaposlenja(DateTime datumZaposlenja)
        {
            this.datumZaposlenja = datumZaposlenja;
        }
        public DateTime getDatumPrekidaZaposlenja()
        {
            return this.datumPrekidaZaposlenja;
        }

        public void setDatumPrekidaZaposlenja(DateTime datumPrekidaZaposlenja)
        {
            this.datumPrekidaZaposlenja = datumPrekidaZaposlenja;
        }
    }
}
