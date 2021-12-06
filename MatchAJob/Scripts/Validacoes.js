
var Excluir = function (id, evento) {
    if (confirm("Confirme Excluir")) { return true; }
    else { evento.preventDefault(); return false; }
}


