﻿using Progress.Communication.Requests;
using Progress.Communication.Responses;
using Progress.Exception;
using Progress.Exception.ExceptionBase;
using Progress.Infrastructure;
using Progress.Infrastructure.Entitites;

namespace Progress.Aplication.UseCases.Produtos.Register
{
    public class RegisterProdutoUseCase
    {
        public ResponseProdutoDetailJson Execute(RequestRegisterProdutoJson request)
        {
            Validate(request);

            var dbContext = new ProgressDbContext();
            var entity = new Produto { 
               Nome = request.Nome,
               Descricao = request.Descricao
            };
            dbContext.Produtos.Add(entity);
            dbContext.SaveChanges();

            return new ResponseProdutoDetailJson { 
                ID = entity.ID,
                Nome = entity.Nome,
                Descricao = entity.Descricao
            };
        }

        private void Validate(RequestRegisterProdutoJson request)
        {
            if (string.IsNullOrWhiteSpace(request.Nome))
            {
                throw new ProdutosException(ResourceErrorMessages.NOME_PRODUTO_VAZIO);
            }

            if (string.IsNullOrWhiteSpace(request.Descricao))
            {
                throw new ProdutosException(ResourceErrorMessages.DESCRICAO_VAZIA);
            }
        }
    }
}
