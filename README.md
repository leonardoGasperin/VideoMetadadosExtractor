# Projeto Razor Pages com Xabe.FFmpeg

Este é um exemplo de projeto Razor Pages que demonstra como criar um endpoint para receber um vídeo em memória e usar a biblioteca Xabe.FFmpeg para coletar informações de metadados do arquivo de vídeo e mostrá-las em uma página da web sem a necessidade de recarregar a página.

## Pré-requisitos

Certifique-se de que você tenha os seguintes pré-requisitos instalados em sua máquina:

- .NET 8 SDK ou superior
- Visual Studio (ou sua IDE preferida) para desenvolvimento

## Configuração do Projeto

1. Clone este repositório para sua máquina local:

```bash
[git clone https://github.com/seu-usuario/projeto-razor-pages-xabe-ffmpeg.git](https://github.com/leonardoGasperin/VideoMetadadosExtractor)https://github.com/leonardoGasperin/VideoMetadadosExtractor
```
1. Abra o projeto em sua IDE preferida (por exemplo, Visual Studio).
2. Certifique-se de que a biblioteca Xabe.FFmpeg esteja instalada no projeto. Você pode instalar a biblioteca usando o NuGet Package Manager ou adicionando a referência manualmente ao arquivo .csproj.
`<ItemGroup>
    <PackageReference Include="Xabe.FFmpeg" Version="4.0.0" />
</ItemGroup>`

Execute o projeto para iniciar o servidor da web local.

# Uso
Neste projeto, você encontrará um endpoint Razor Pages chamado "Upload.cshtml" que permite fazer upload de um vídeo em memória e exibe as informações de metadados na mesma página sem a necessidade de recarregar.

1. Acesse a página "Upload" em seu navegador, geralmente em http://localhost:5000/Upload.

2. Selecione um vídeo para fazer upload.

3. O sistema usará a biblioteca Xabe.FFmpeg para coletar informações de metadados do vídeo em memória.

4. As informações de metadados, como título, duração, resolução, codec, etc., serão exibidas na página sem a necessidade de recarregar.

# Personalização
Você pode personalizar este projeto de acordo com suas necessidades adicionando mais funcionalidades, como a capacidade de fazer o download do vídeo modificado ou compartilhar as informações de metadados em redes sociais. Sinta-se à vontade para explorar e expandir o projeto.

# Contribuição
Se você deseja contribuir para este projeto, sinta-se à vontade para abrir issues ou enviar pull requests. Sua contribuição é bem-vinda!
