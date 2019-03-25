------------------CONSULTAS----------------------------
/////////////////
select titulo, descripcion,fechaentrega, valor, maestro.nombres, materia.nombre from actividad 
Inner join maestro on
actividad.registro= maestro.registro
Inner join materia on
materia.idmateria=actividad.idmateria;
////////////////////
////////////////////
select actividad.idactividad, actividad.titulo, actividad.descripcion, actividad.valor, materia.nombre, asignacionactividad.nota, asignacionactividad.observacion, asignacionactividad.estado from asignacionactividad
inner join actividad on
actividad.idactividad=asignacionactividad.idactividad
inner join materia on
actividad.idmateria=materia.idmateria
where asignacionactividad.carnet = 1;
///////////////////////////////////////
