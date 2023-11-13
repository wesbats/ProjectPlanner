# Project Planner

O Project Planner é uma aplicação de gerenciamento de projetos e tarefas, permitindo que os usuários organizem suas atividades de forma eficiente.

## Instruções de Uso

1. **Execução:**
   Certifique-se de ter o ambiente de desenvolvimento configurado corretamente. Em seguida, execute a aplicação a partir da classe `Program` no namespace `ProjectPlanner`.
```
dotnet run
```

2. **Menu Principal:**
Ao iniciar a aplicação, você será apresentado ao menu principal, que exibirá as opções disponíveis, incluindo a lista de projetos existentes. Use as `setas` para navegar e pressione `Enter` para selecionar uma opção.

3. **Criar Nova Branch:**
Se não houver nenhuma branch existente, a aplicação solicitará a criação da primeira branch. Siga as instruções para dar um nome à sua nova branch.

4. **Operações em uma Branch:**
Ao selecionar uma branch, você terá várias opções, incluindo a criação de uma nova branch, uma nova tarefa, e a capacidade de voltar ao menu anterior. Além disso, é possível editar, remover `Delete` e renomear `R` branches e tarefas.

5. **Salvar e Sair:**
Para salvar suas alterações e sair da aplicação, selecione a opção correspondente no menu principal.

## Estrutura do Projeto

O projeto está estruturado da seguinte forma:

- **Contollers:** Contém os controladores responsáveis pela lógica de negócios.
- **Models:** Contém as classes de modelo para representar projetos, tarefas, etc.
- **Views:** Contém as interfaces de usuário e lógica de apresentação.

## Contribuições

Contribuições são bem-vindas! Se deseja contribuir, siga estas etapas:

1. Faça um fork do repositório.
2. Crie um branch para a sua feature: `git checkout -b feature/nova-feature`.
3. Faça commit das suas alterações: `git commit -m 'Adiciona nova feature'`.
4. Envie as alterações para o seu fork: `git push origin feature/nova-feature`.
5. Abra um pull request.
