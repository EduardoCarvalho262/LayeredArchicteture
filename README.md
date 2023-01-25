# LayeredArchitecture
- O mais comum padrão de arquiteturas.
- É geralmete uma escolha natural e tradicional encontrada na maiorias das companhias

## Descrição

São organizadas em componentes e elas estão presentes em camadas horizontais. Cada camada operando em um específica função dentro da aplicação.
- Não tem número específico de camadas, mas geralmente as aplicações tem:
	- Presentation.
	- Business.
	- Persistence.
	- Database.
- Alguns casos business e persistence estão na mesma camada
- Cada camada dentro da arquitetura formam uma abstração ao redor do trabalho para satisfazer uma regra de negócio em particular.
- Uma camada não se preocupa com o que a outra faz.

Exemplo:

<img align="center" height="400" width="400" src="https://www.oreilly.com/api/v2/epubs/9781491971437/files/assets/sapr_0104.png">

Análise do Pattern:
- Agilidade Geral: Baixa.
- Facilidade de implantação: Baixa.
- Testabilidade: Alta.
- Performance: Baixa.
- Escalabilidade: Baixa.
- Facilidade de desenvolvimento: Alta.
