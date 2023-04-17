﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Exercicio.Repository
{
    public class JsonPersistenciaRepository
    {        
        public static void Salvar(string nomeArquivo, dynamic argument)
        {
            string stringJson = JsonConvert.SerializeObject(argument);

            var sistema = Environment.OSVersion.Platform;

            string caminhoArquivo;

            if (sistema != PlatformID.Unix)
                caminhoArquivo = Directory.GetCurrentDirectory() + @"\" + nomeArquivo;
            else
                caminhoArquivo = Directory.GetCurrentDirectory() + "/" + nomeArquivo;


            File.WriteAllText(caminhoArquivo, stringJson);
        }

        public static List<dynamic> Lista(string nomeArquivo)
        {
            string caminhoArquivo;

            var sistema = Environment.OSVersion.Platform;

            if (sistema != PlatformID.Unix)
                caminhoArquivo = Directory.GetCurrentDirectory() + @"\" + nomeArquivo;
            else
                caminhoArquivo = Directory.GetCurrentDirectory() + "/" + nomeArquivo;

            if (!File.Exists(caminhoArquivo))
                return new List<dynamic>();

            string stringJson = File.ReadAllText(caminhoArquivo);

            List<dynamic> clientes = JsonConvert.DeserializeObject<List<dynamic>>(stringJson);

            return clientes;
        }
    }
}