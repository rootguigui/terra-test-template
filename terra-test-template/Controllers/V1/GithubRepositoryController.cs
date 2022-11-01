using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Collections.Generic;
using System.Net;
using terra_test_template.Repositories.V1.GithubServices;
using terra_test_template.Repositories.V1.GithubServices.Models.CreateRepository;
using terra_test_template.Repositories.V1.GithubServices.Models.CreateWebhookRepository;
using terra_test_template.Repositories.V1.GithubServices.Models.ListBranchesRepository;
using terra_test_template.Repositories.V1.GithubServices.Models.ListWebhookRepository;
using terra_test_template.Repositories.V1.GithubServices.Models.UpdateWebhookRepository;

namespace terra_test_template.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GithubRepositoryController : ControllerBase
    {
        private readonly IGithubRepository _repository;

        public GithubRepositoryController(IGithubRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna as branches existentes no repositorio
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna as branches</response>
        /// <response code="400">Erro interno</response>
        /// <response code="500">Internal Server Errror</response>
        [HttpGet]
        [Route("branches/{owner}/{repo}")]
        [ProducesResponseType(typeof(List<ListBranchesRepositoryResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetRepositoryBranches(string owner, string repo)
        {
            try
            {
                var result = await _repository.ListBranchesRepository(owner, repo, HttpContext.Request.Headers["token"]);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cria um novo Repositorio no github
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Retorna o repositório criado</response>
        /// <response code="400">Erro interno</response>
        /// <response code="500">Internal Server Errror</response>
        [HttpPost]
        [Route("repo")]
        [ProducesResponseType(typeof(CreateRepostitoryResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRepository([FromBody] CreateRepositoryDTO body)
        {
            try
            {
                var result = await _repository.CreateRepository(HttpContext.Request.Headers["token"], body);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos os webhooks criados no repositório
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna os webhooks cadastrado no repositório</response>
        /// <response code="400">Erro interno</response>
        /// <response code="500">Internal Server Errror</response>
        [HttpGet]
        [Route("webhooks/{owner}/{repo}")]
        [ProducesResponseType(typeof(List<ListWebhooksRepositoryResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetWebhooksFromRepository(string owner, string repo)
        {
            var result = await _repository.ListListWebhooksRepository(owner, repo, HttpContext.Request.Headers["token"]);

            return Ok(result);
        }

        /// <summary>
        /// Cria um novo webhook no repositório
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna o webhook cadastrado no repositório</response>
        /// <response code="400">Erro interno</response>
        /// <response code="500">Internal Server Errror</response>
        [HttpPost]
        [Route("webhooks/{owner}/{repo}")]
        [ProducesResponseType(typeof(CreateWebhookRepositoryResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> CreateWebhookRepository([FromBody] CreateWebhookRepositoryDto body, string owner, string repo)
        {
            try
            {
                var result = await _repository.CreateWebhookRepository(owner, repo, HttpContext.Request.Headers["token"], body);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// atualiza um novo webhook no repositório
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna o webhook atualizado no repositório</response>
        /// <response code="400">Erro interno</response>
        /// <response code="500">Internal Server Errror</response>
        [HttpPut]
        [Route("webhooks/{owner}/{repo}/{id}")]
        [ProducesResponseType(typeof(UpdateWebhookRepositoryResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateWebhookRepository([FromBody] UpdateWebhookRepositoryDto body, string owner, string repo, string id)
        {
            try
            {
                var result = await _repository.UpdateWebhookRepository(owner, repo, id, HttpContext.Request.Headers["token"], body);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
