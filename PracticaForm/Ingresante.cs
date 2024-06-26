﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaForm
{
    public class Ingresante
    {
        string nombre;
        string direccion;
        int edad;
        string cuit;
        string genero;
        string pais;
        string[] curso = new string[] {" "," "," "}; //para evitar excepcion de objeto no inicializado => referencia nula

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Pais { get => pais; set => pais = value; }
        public string[] Curso { get => curso; set => curso = value; }
        public string Cuit { get => cuit; set => cuit = value; }

        public Ingresante(string nombre, string direccion, int edad, string cuit, string genero, string pais, string[] curso)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Edad = edad;
            this.Cuit = cuit;
            this.Genero = genero;
            this.Curso = curso;
            this.Pais = pais;
        }

        public Ingresante() { }

        public String Mostrar()
        {
            StringBuilder contenido = new StringBuilder();
            contenido.Append("Nombre: " + Nombre + "\n");
            contenido.Append("Direccion: " + Direccion + "\n");
            contenido.Append("Edad: " + Edad + "\n");
            contenido.Append("Cuit: " + Cuit + "\n");
            contenido.Append("Genero: " + Genero + "\n");
            contenido.Append("Pais: " + Pais + "\n");
            contenido.Append("Curso/s: \n" + curso[0] + "\n" + curso[1] + "\n" + curso[2]);
            return contenido.ToString();
        }
    }
}
