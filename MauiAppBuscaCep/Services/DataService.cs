﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppBuscaCep.Models;
using Newtonsoft.Json;

namespace MauiAppBuscaCep.Services
{
    public class DataService
    {
        public static async Task<Endereco> GetEnderecoByCep(string cep)
        {
            Endereco end;

            using (HttpClient client = new HttpClient())
            {
                string url = "http://localhost:8000endereco/by-cep?cep=" + cep;

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    end = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else 
                {
                    throw new Exception(response.RequestMessage.Content.ToString());
                }
            }
            return end;
        }


        public static async Task<List<Bairro>> GetBairrosByIdCidade(int id_cidade)
        {
            List<Bairro> arr_bairros = new List<Bairro>();

            using (HttpClient client = new HttpClient())
            {
                string url = "https://cep.metoda.com.br/bairro/by-cidade?id_cidades" + id_cidade;

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_bairros = JsonConvert.DeserializeObject<List<Bairro>>(json);
                }
                else
                {
                    throw new Exception(response.RequestMessage.Content.ToString());
                }
            }
            return arr_bairros;
        }

        public static async Task<List<Cidade>> GetCidadesByEstado(string uf) 
        {
            List<Cidade> arr_cidades = new List<Cidade>();

            using (HttpClient client = new HttpClient()) 
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/ciade/by-uf?uf=" + uf);

                if (response.IsSuccessStatusCode) 
                { 
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_cidades = JsonConvert.DeserializeObject<List<Cidade>>(json);
                }
                else 
                {
                    throw new Exception(response.RequestMessage.Content.ToString());
                }
            }
            return arr_cidades;
        }

        public static async Task<List<Logradouro>> GetLogradourosByBairroAndIdCidade(string bairro, int id_cidade)
        {
            List<Logradouro> arr_logradouros = new List<Logradouro>();

            using (HttpClient client = new HttpClient()) 
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/logradouro/by-bairro?id_cidade=" + id_cidade + "&bairro=" + bairro);

                if (response.IsSuccessStatusCode) 
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_logradouros = JsonConvert.DeserializeObject<List<Logradouro>>(json);
                }
                else 
                {
                    throw new Exception(response.RequestMessage.Content.ToString());
                }
            }
            return arr_logradouros;
        }

        public static async Task<List<Cep>> GetCepsByLogradouro(string logradouro) 
        {
            List<Cep> arr_ceps = new List<Cep>();

            using (HttpClient client = new HttpClient()) 
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/cep/by-logradouro?logradouro=" + logradouro);

                if (response.IsSuccessStatusCode) 
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_ceps = JsonConvert.DeserializeObject<List<Cep>>(json);
                }
                else 
                {
                    throw new Exception(response.RequestMessage.Content.ToString());
                }
            }
            return arr_ceps;
        }
            
    }
}
