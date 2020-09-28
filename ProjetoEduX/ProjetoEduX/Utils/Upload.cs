using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace ProjetoEduX.Utils
{
    public static class Upload
    {

        public static string Local(IFormFile file)
        {
            //Gera o nome do arquivo utilizando o GUID
            //Concatena a extensão do arquivo
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);

            //Concatena o diretório da aplicação corrente e concatena com a pasta que vai ser salvo o arquivo
            //Concatena com o nome do arquivo; caminho físico>> c://user/aplicacao/upload/imagens/imagem.png
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\upload\imagens", nomeArquivo);

            //Gera um objeto FileStream que vai armazenar a imagem
            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

            //Copia a imagem para o local informado
            file.CopyTo(streamImagem);

            return "http://localhost:64698/upload/imagens/" + nomeArquivo;
        }
    }
}


