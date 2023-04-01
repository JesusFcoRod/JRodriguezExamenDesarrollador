$(document).ready(function () { //click
    GetAll();
    EstadoGetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5228/api/Empleado/GetAll',
        success: function (result) { //200 OK 
            $('#tblEmpleados tbody').empty();
            $.each(result.objects, function (i, empleado) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> '
                    + '<a href="#" onclick="GetById(' + empleado.idEmpleado + ')">'
                    + '<i class="bi bi-pencil-square" style="color: black"></i>'
                    + '</a> '
                    + '</td>'
                    + "<td  id='id' class='text-center'>" + empleado.idEmpleado + "</td>"
                    + "<td  id='id' class='text-center'>" + empleado.numeroNomina + "</td>"
                    + "<td class='text-center'>" + empleado.nombre + "</td>"
                    + "<td class='text-center'>" + empleado.apellidoPaterno + "</td>"
                    + "<td class='text-center'>" + empleado.apellidoMaterno + "</td>"
                    + "<td class='text-center'>" + empleado.estado.nombre + "</td>"
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Delete(' + empleado.idEmpleado + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'
                    + "</tr>";
                $("#tblEmpleados tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function Actualizar() {
    var empleado = {
        idEmpleado: $('#txtIdEmpleado').val(),
        NumeroNomina: $('#txtNumeroNomina').val(),
        Nombre: $('#TxtNombre').val(),
        apellidoPaterno: $('#txtApellidoPaterno').val(),
        apellidoMaterno: $('#txtApellidoMaterno').val(),
        Estado: {
            idEstado: $('#ddlEstado').val()
        }
    }

    if (empleado.idEmpleado == '') {
        Add(empleado);
    }
    else {
        Update(empleado);
    }
}
function Add(empleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5228/api/Empleado/Add',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify({
            NumeroNomina: empleado.NumeroNomina,
            Nombre: empleado.Nombre,
            apellidoPaterno: empleado.apellidoPaterno,
            apellidoMaterno: empleado.apellidoMaterno,
            Estado: {
                idEstado: empleado.Estado.idEstado
                }
        }),
        success: function (result) {
            alert('Registro exitoso');
            $('#MyModal').modal('show');
            $('#ModalUpdate').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error al agregar el registro');
        }
    });
};


function GetById(idEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5228/api/Empleado/GetById/' + idEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.object.idEmpleado);
            $('#txtNumeroNomina').val(result.object.numeroNomina);
            $('#TxtNombre').val(result.object.nombre);
            $('#txtApellidoPaterno').val(result.object.apellidoPaterno);
            $('#txtApellidoMaterno').val(result.object.apellidoMaterno);
            $('#ddlEstado').val(result.object.estado.idEstado);

            $('#ModalUpdate').modal('show');
        },
        error: function () {
            alert('Error al consultar el empleado' + result.responseJSON.ErrorMessage);
        }
    });
};

function Update(empleado) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5228/api/Empleado/Update',
        dataType: 'json',
        data: JSON.stringify(empleado),
        contentType: 'application/json; charset-utf-8',
        success: function (result) {
            $('#myModal').modal('show');
            $('#ModalUpdate').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error al actualizar al empleado' + result.responseJSON.ErrorMessage);
        }
    });
};

function Delete(idEmpleado) {
    if (confirm("Confira que desea eliminar el registro?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:5228/api/Empleado/Delete/' + idEmpleado,
            success: function (result) {
                $('#myModal').modal('show');
                GetAll();
            },
            error: function (result) {
                alert('Error al intentar eliminar el registro' + result.responseJSON.ErrorMessage);
            }
        });
    }
};

function Modal() {
    $('#ModalUpdate').modal('show');
    IniciarEmpleado();
}

function ModalClose() {
    $('#ModalUpdate').modal('hide');
}

function EstadoGetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5228/api/Empleado/EstadoGetAll',
        success: function (result) {
            $("#ddlEstado").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.objects, function (i, estado) {
                $("#ddlEstado").append('<option value="'
                    + estado.idEstado + '">'
                    + estado.nombre + '</option>');
            });
        }
    });
}

function IniciarEmpleado() {
    var empleado = {
        idEmpleado: $('#txtIdEmpleado').val(''),
        NumeroNomina: $('#txtNumeroNomina').val(''),
        Nombre: $('#TxtNombre').val(''),
        apellidoPaterno: $('#txtApellidoPaterno').val(''),
        apellidoMaterno: $('#txtApellidoMaterno').val(''),
        Estado: {
            idEstado: $('#ddlEstado').val(0)
        }

    }
}
