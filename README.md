# 🚀 Avaliação NIUCO

**Candidato:** Valnei Vinicios  
**Projeto:** MarsExploration  
**Desafio:** Exploração de Marte com Rovers

---

## 🛠️ FERRAMENTA

### Instalação do Ambiente

1. **Download do Visual Studio:**  
   👉 [https://visualstudio.microsoft.com/vs/community](https://visualstudio.microsoft.com/vs/community)

2. **Instalação da Carga de Trabalho:**  
   - Abra o **Instalador do Visual Studio**  
   - Vá até: `Ferramentas > Obter Ferramentas e Recursos`  
   - Marque a opção **"Desenvolvimento para área de trabalho com .NET"**  
   - Clique em **Instalar** e aguarde a conclusão.

---

## 📁 SOLUÇÃO

A solução contém **2 projetos**:

| Projeto              | Tipo               | .NET Version | Descrição                      |
|----------------------|--------------------|--------------|--------------------------------|
| `MarsExploration`    | Console Application| 8.0          | Projeto principal              |
| `MarsExplorationTest`| Testes com xUnit   | 8.0          | Projeto de testes automatizados|

---

## 🌌 Desafio: Explorando Marte

Um conjunto de sondas (rovers) foi enviado pela NASA para Marte e pousou em um planalto retangular.  
Essas sondas devem explorar a área mapeada seguindo uma série de instruções que controlam seu movimento e direção.

---

## 🐞 Debugging

Durante os testes com o seguinte cenário:

```csharp
var plateau = new Plateau(5, 5);
var rover = new Rover(new Position(3, 2), Direction.N, plateau);
rover.ExecuteCommands("MRM");
Console.WriteLine($"{rover.Position.X} {rover.Position.Y} {rover.Direction}");
```

Através do **Visual Studio**, utilizei as teclas `F10 (Step Over)` e `F11 (Step Into)` para investigar a execução linha a linha.

Foi observado que o método `Occupy` da classe `Plateau` **não validava se a posição já estava ocupada**, o que poderia causar inconsistências.  
Adicionei a seguinte verificação:

```csharp
if (IsOccupied(pos))
    throw new InvalidOperationException($"A posição {pos.X},{pos.Y} já está ocupada por outra sonda.");
```

Com isso, garantimos que o **Plateau** controle corretamente o uso das suas coordenadas, mantendo a responsabilidade dentro de seu domínio.

---

## 🧱 Padrões de Projeto

### ✅ **Command Pattern**  

> O padrão **Command** encapsula uma solicitação como um objeto, permitindo parametrizar ações e controlar a execução de comandos.

#### Componentes:

- **Invoker**:  
  `Rover.ExecuteCommands(string commandSequence)`  
  Responsável por percorrer a sequência de comandos e invocá-los.

- **Receiver**:  
  `Rover`  
  Contém a lógica de movimentação (`MoveForward`, `TurnLeft`, `TurnRight`).

- **Commands**:  
  `MoveForwardCommand`, `TurnLeftCommand`, `TurnRightCommand`  
  Executam ações no rover.

#### 🏭 Factory Pattern:

Para traduzir uma string de comandos (`e.g., "MRM"`) em instâncias de comandos, foi implementada a classe:

```csharp
HoverMovementCommandFactory
```

Ela interpreta cada caractere e retorna a instância correta do comando correspondente.

---

## 📌 Exemplo:

Dado o comando:

```
"MRM"
```

A execução acontece assim:

1. `M` → `MoveForwardCommand`
2. `R` → `TurnRightCommand`
3. `M` → `MoveForwardCommand`

Cada comando é encapsulado como objeto, mantendo **baixa acoplagem**, **alta coesão** e favorecendo a **extensibilidade**.

---

## 🔄 Integração Contínua

A solução está integrada com **GitHub Actions**. A pipeline é acionada a cada `push` ou `pull request` na branch `main`. Ela realiza os seguintes passos:

1. **Checkout do código**
2. **Instalação do .NET 8.0**
3. **Restauração dos pacotes NuGet da solução**
4. **Build da solução com configuração `Release`**
5. **Execução dos testes com relatório `trx`**

Exemplo de configuração no workflow:

```yaml
- name: Restaurar pacotes
  run: dotnet restore ./MarsExploration/MarsExploration.sln

- name: Build do projeto
  run: dotnet build ./MarsExploration/MarsExploration.sln --no-restore --configuration Release

- name: Executar testes
  run: dotnet test ./MarsExploration/MarsExploration.sln --no-build --configuration Release --logger "trx"
```

Isso garante que a solução esteja sempre funcional e testada a cada alteração publicada.

## ✅ Considerações Finais

O uso do padrão **Command** e de uma **Factory isolada** se mostrou ideal para lidar com instruções dinâmicas e encadeadas.

A arquitetura está preparada para futuras extensões, como:  
- Adição de novos comandos  
- Log da trajetória dos rovers  
- Controle de múltiplas sondas simultaneamente  

---

📎 Obrigado pela avaliação!

