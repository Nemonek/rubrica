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
        private int _idPersona;
        private TipoContatto _tipo;
        private string _valore;

        public int IdPersona { get => this._idPersona; }
        public TipoContatto Tipo { get => this._tipo; }
        public string Valore { get => this._valore; }

        public Contatto(string r)
        {
            string[] values = r.Split(';');
            this._idPersona = (int.TryParse(values[0], out int n)) ? n : 0 ;
            this._tipo = (Enum.TryParse(values[1], out TipoContatto t)) ? t : TipoContatto.nessuno;
            this._valore = values[2];
        }
    }
}
