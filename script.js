const apiBase = "https://localhost:7075/api/Contato"; 

document.getElementById("contatoForm").addEventListener("submit", async (e) => {
    e.preventDefault();

    const id = document.getElementById("id").value;
    const contato = {
        nome: document.getElementById("nome").value,
        apelido: document.getElementById("apelido").value,
        cpf: document.getElementById("cpf").value,
        telefone: document.getElementById("telefone").value,
        email: document.getElementById("email").value
    };

    if (id) {
        await fetch(`${apiBase}/${id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(contato)
        });
    } else {
        await fetch(apiBase, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(contato)
        });
    }

    limparFormulario();
    carregarContatos();
});

async function carregarContatos() {
    const data = document.getElementById("filtroData").value;
    const url = data ? `${apiBase}/Data?data=${data}` : apiBase;

    const resposta = await fetch(url);
    const contatos = await resposta.json();

    const tbody = document.getElementById("tabelaContatos");
    tbody.innerHTML = "";

    contatos.forEach(contato => {
        const tr = document.createElement("tr");

        tr.innerHTML = `
            <td>${contato.nome}</td>
            <td>${contato.apelido}</td>
            <td>${contato.cpf}</td>
            <td>${contato.telefone}</td>
            <td>${contato.email}</td>
            <td>
                <button onclick="editarContato(${contato.id})">Editar</button>
                <button onclick="excluirContato(${contato.id})">Excluir</button>
            </td>
        `;

        tbody.appendChild(tr);
    });
}

async function editarContato(id) {
    const resposta = await fetch(`${apiBase}/${id}`);
    const contato = await resposta.json();

    document.getElementById("id").value = contato.id;
    document.getElementById("nome").value = contato.nome;
    document.getElementById("apelido").value = contato.apelido;
    document.getElementById("cpf").value = contato.cpf;
    document.getElementById("telefone").value = contato.telefone;
    document.getElementById("email").value = contato.email;
}

async function excluirContato(id) {
    if (confirm("Tem certeza que deseja excluir?")) {
        await fetch(`${apiBase}/${id}`, { method: "DELETE" });
        carregarContatos();
    }
}

function limparFormulario() {
    document.getElementById("id").value = "";
    document.getElementById("contatoForm").reset();
}

carregarContatos();
