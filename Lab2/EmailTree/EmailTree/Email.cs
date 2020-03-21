using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTree
{
    class Email : IComponent
    {
        private string _title;
        private string _from;
        private string _to;
        private decimal _size;
        private string _text;
        public Email()
        {
            this._title = "test email";
            this._from = "jan";
            this._to = "jadwiga";
            this._size = 130;
            this._text = "To jest testowy email";
        }
        public Email(string title, string from, string to, decimal size, string text)
        {
            this._title = title;
            this._from = from;
            this._to = to;
            this._size = size;
            this._text = text;
        }

        public string Title { get => _title; set => _title = value; }
        public string From { get => _from; set => _from = value; }
        public string To { get => _to; set => _to = value; }
        public decimal Size { get => _size; set => _size = value; }
        public string Text { get => _text; set => _text = value; }

        public decimal CalculateSize()
        {
            return this._size;
        }

        public string DisplayStructure(string prefix)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{prefix}********************");
            sb.AppendLine($"{prefix}*Title: {this._title}");
            sb.AppendLine($"{prefix}*From: {this._from}");
            sb.AppendLine($"{prefix}*To: {this._to}");
            sb.AppendLine($"{prefix}*'{this._text}'");
            sb.AppendLine($"{prefix}********************");


            return sb.ToString();
        }
    }
}
