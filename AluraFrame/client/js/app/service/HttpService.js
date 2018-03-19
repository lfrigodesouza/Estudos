class HttpService {
    get(url) {
        return new Promise((resolve, reject) => {
            let xhr = new XMLHttpRequest();

            xhr.open('GET', url);

            xhr.onreadystatechange = () => {
                // 0 - Não inciada
                // 1- conexão estabelecida
                // 2 - requisicao recebida
                // 3 - processando requisição
                // 4 - requisicao concluida e resposta pronta
                if (xhr.readyState == 4) {
                    if (xhr.status == 200) {
                        resolve(JSON.parse(xhr.responseText));
                    } else {
                        console.log(xhr.responseText);
                        reject(xhr.responseText);
                    }
                }
            };
            xhr.send();
        });
    }
}