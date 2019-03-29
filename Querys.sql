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
///////////////////////////////////////
select publicacion.titulo,texto, publicacion.fecha, publicacion.idtipo from publicacion
inner join examen on
publicacion.idexamen = examen.idexamen
inner join maestro on
publicacion.registro = maestro.registro
where maestro.registro = 1;
////////////////////////////////////////
insert into publicacion values('Tarea 22','Hoja de trabajo','2019-03-30 23:59:35.000',1,null,null,20,null,1);
/////////////////////
select asignacionexamen.idasignacionexamen, asignacionexamen.idexamen,examen.titulo, examen.descripcion, materia.nombre, asignacionexamen.nota from asignacionexamen
inner join examen on
examen.idexamen=asignacionexamen.idexamen
inner join materia on
examen.idmateria=materia.idmateria
where asignacionexamen.carnet = 1;
///////////////////////////////////////
select maestro.nombres,grado.nombre, carrera.nombre, asignacioncarrera.ciclo from asignacioncarrera 
inner join maestro on
maestro.registro = asignacioncarrera.registro
inner join grado on
grado.idgrado = asignacioncarrera.idgrado
inner join carrera on
carrera.idcarrera = asignacioncarrera.idcarrera
////////////////////////////////////
(select asignacionactividad.carnet, actividad.idmateria, actividad.titulo ,calificacion.nota, calificacion.descripcion from calificacion 
inner join asignacionactividad on
asignacionactividad.idasignacionactividad = calificacion.idasignacionactividad
inner join actividad on
actividad.idactividad = asignacionactividad.idactividad
where asignacionactividad.carnet = 1 and actividad.idmateria =1
)
union
(select asignacionexamen.carnet,examen.idmateria, examen.titulo,calificacion.nota, calificacion.descripcion from calificacion 
inner join asignacionexamen on
asignacionexamen.idasignacionexamen= calificacion.idasignacionexamen
inner join examen on
examen.idexamen = asignacionexamen.idexamen
where asignacionexamen.carnet = 1
and examen.idmateria =1
)
//////////////////////////////////////////
select respuesta.idrespuesta, respuesta.idpregunta, respuesta.opcion,respuesta.estado from Respuesta
inner join pregunta on
pregunta.idpregunta = respuesta.idpregunta 
where pregunta.idpregunta = 4
and respuesta.estado = 'true';

