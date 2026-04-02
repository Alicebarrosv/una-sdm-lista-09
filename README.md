# Atividade 9

## Nome: Alice Barros Viana

### 1. A Efemeridade do "In-Memory":
+ Cadastre três candidatos via Swagger (POST).
+  Verifique se eles aparecem na listagem (GET).

<img width="417" height="387" alt="image" src="https://github.com/user-attachments/assets/37e3b274-b33b-4eef-8449-2776f9ae913c" />

+ No terminal do VS Code, pare a aplicação (Ctrl + C) e execute
dotnet run novamente.

<img width="264" height="120" alt="image" src="https://github.com/user-attachments/assets/e236dd3e-6070-4902-8bd0-d2461d54282a" />

+ Pergunta: Os dados ainda estão lá? Explique por que isso
acontece em um banco In-Memory e em que cenário real isso seria
um problema (ou uma solução).
##### Resposta:
Depois que rodei o código novamente, percebi que os candidatos cadastrados haviam desaparecido. Isso acontece porque em um banco de dados In-Memory as informações são armazenadas diretamente na memória RAM, que é volátil e não mantém os dados após o encerramento da execução ou reinicialização do sistema. 

### 2. Semântica HTTP:
+ Tente realizar um POST enviando um objeto vazio. O que
acontece?
##### Resposta:
Retorno de um 400 Bad Request, indicando que a requisição foi inválida.

<img width="740" height="309" alt="image" src="https://github.com/user-attachments/assets/460b62e1-f85b-4273-9373-5570592ae349" />

+ Tente realizar um DELETE em um ID que não existe (ex: ID 99).
Sua API retornou 204 No Content ou 404 Not Found? Qual seria o
comportamento ideal para um sistema distribuído robusto?

##### Resposta:
 Retorna 404 Not Found, indicando que o recurso solicitado não existe.

<img width="628" height="269" alt="image" src="https://github.com/user-attachments/assets/65a535ce-d309-464f-b86b-67448d077e6f" />

### 3. Refinando o Modelo:
No arquivo Candidato.cs, adicione um novo campo:
public string ViceNome { get; set; } = string.Empty;

<img width="492" height="334" alt="image" src="https://github.com/user-attachments/assets/3dd8549c-3056-44af-b186-a1f9bbfb8d85" />

o Atualize o Controller para que o PUT também altere o nome do
vice.
o Teste a alteração no Swagger.

<img width="250" height="215" alt="image" src="https://github.com/user-attachments/assets/4881ecf9-026e-4ce1-abb2-58b257f89bb3" />

### 4. Validação de Regra de Negócio (O "Pulo do Gato"):
No método Post (Create) do seu Controller, adicione uma validação:

+ Regra: Não podem existir dois candidatos com o mesmo número
de eleição.
+ Dica de Código: Use _context.Candidatos.Any(c => c.Numero == novoCandidato.Numero) antes de salvar.
<img width="657" height="238" alt="image" src="https://github.com/user-attachments/assets/ca26172d-45d9-4bab-9f4a-37405e3eb8fd" />

Se já existir, retorne um BadRequest("Número já cadastrado").

<img width="522" height="186" alt="image" src="https://github.com/user-attachments/assets/15c28972-26fa-4f9b-80a9-a82690bb62a0" />

### 5. Desafio de Busca (Filtro):
+ Crie um novo método GET no Controller que aceite um parâmetro de busca:
api/candidatos/partido/{nomeDoPartido}.

+ Este método deve retornar apenas os candidatos daquele partido
específico.
+Dica: Use _context.Candidatos.Where(c => c.Partido == nomeDoPartido).ToList().
#### Código

<img width="954" height="235" alt="image" src="https://github.com/user-attachments/assets/95387af5-79bf-40ed-b3b0-536e270d0482" />


#### Swagger
<img width="581" height="861" alt="image" src="https://github.com/user-attachments/assets/36ffc5c5-e6fe-4034-8701-bc26696321ad" />

## Parte 3: Reflexão sobre Sistemas Distribuídos
### 6. Idempotência na Prática:
+ Execute o método DELETE para o ID 1 duas vezes seguidas.
  
  <img width="783" height="324" alt="image" src="https://github.com/user-attachments/assets/5b9b15b9-df36-4dca-897e-df6a89eb8816" />

+ O resultado da segunda execução foi diferente da primeira no que diz respeito ao estado do banco de dados?

##### Resposta:
  Sim, deu 404 not found.
  
+ Isso prova que o DELETE é um método idempotente? Justifique.

##### Resposta:
 Sim, pois múltiplas requisições idênticas tera o mesmo efeito que uma única.







