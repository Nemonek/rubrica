using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piredda.Riccardo._4i.rubricaWPF
{
    public enum TipoContatto
    {
        email,
        numero,
        web,
        instagram,
        nessuno
    }
    public class Contatto
    {
        protected int _idPersona;
        protected TipoContatto _tipo;
        protected string _valore;

        public int IdPersona { get => this._idPersona; }
        public TipoContatto Tipo { get => this._tipo; }
        public string Valore { get => this._valore; }

        public Contatto() { }

        public Contatto(string r)
        {
            string[] values = r.Split(';');
            this._idPersona = (int.TryParse(values[0], out int n)) ? n : 0 ;
            this._tipo = (Enum.TryParse(values[1], out TipoContatto t)) ? t : TipoContatto.nessuno;
            this._valore = values[2];
        }

        public static Contatto CreaEreditante(string r)
        {
            string[] values = r.Split(';');
            int idPersona = (int.TryParse(values[0], out int n)) ? n : 0;
            TipoContatto tipo = (Enum.TryParse(values[1], out TipoContatto t)) ? t : TipoContatto.nessuno;
            string valore = values[2];

            switch (tipo)
            {
                case TipoContatto.email:
                    return new ContattoEmail(idPersona, valore);

                case TipoContatto.numero:
                    return new ContattoNumero(idPersona, valore);
                case TipoContatto.web:
                    return new ContattoWeb(idPersona, valore);
                case TipoContatto.instagram:
                    return new ContattoInstagram(idPersona, valore);

                default:
                    return new ContattoInvalido(idPersona, valore);
            }

        }
        
    }

    public class ContattoEmail : Contatto
    {
        public ContattoEmail(int id, string valore) : base()
        {
            this._tipo = TipoContatto.email;
            this._valore = valore;
            this._idPersona = id;
        }
    }

    public class ContattoNumero : Contatto
    {
        public ContattoNumero(int id, string valore) : base()
        {
            this._tipo = TipoContatto.numero;
            this._valore = valore;
            this._idPersona = id;
        }
    }
    public class ContattoWeb : Contatto
    {
        public ContattoWeb(int id, string valore) : base()
        {
            this._tipo = TipoContatto.web;
            this._valore = valore;
            this._idPersona = id;
        }
    }

    public class ContattoInstagram : Contatto
    {
        public ContattoInstagram(int id, string valore) : base()
        {
            this._tipo = TipoContatto.instagram;
            this._valore = valore;
            this._idPersona = id;
        }
    }
    public class ContattoInvalido : Contatto
    {
        public ContattoInvalido(int id, string valore) : base()
        {
            this._tipo = TipoContatto.nessuno;
            this._valore = valore;
            this._idPersona = id;
        }
    }
}
