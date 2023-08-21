
// Crear la base de datos
use TestTask

// Crear la colección Preguntas
db.createCollection("Preguntas")

// Crear la colección Respuestas
db.createCollection("Respuestas")

// Crear la colección PreguntasRespuestas
db.createCollection("PreguntasRespuestas")

// Crear la colección Tests
db.createCollection("Tests")

// Crear la colección TestPreguntas
db.createCollection("TestPreguntas")

// Crear la colección RespuestasUsuarios
db.createCollection("RespuestasUsuarios")

// Crear la colección ResultadosUsuarios
db.createCollection("ResultadosUsuarios")




//Insertar datos
db.Tests.insertOne({ Identificador: 1, Descripcion: "Primer Test" })


db.Preguntas.insertOne({ Identificador: 1, Descripcion: "¿Cuál es la capital de Francia?" })
db.Preguntas.insertOne({ Identificador: 2, Descripcion: "Selecciona los multiplos de 2" })

db.TestPreguntas.insertOne({ Test_Id: 1, Pregunta_Id: 1 })
db.TestPreguntas.insertOne({ Test_Id: 1, Pregunta_Id: 2 })

db.Respuestas.insertOne({ Identificador: 1, Descripcion: "París", RespuestaCorrecta:true })
db.Respuestas.insertOne({ Identificador: 2, Descripcion: "Madrid", RespuestaCorrecta:false })

db.Respuestas.insertOne({ Identificador: 3, Descripcion: "1", RespuestaCorrecta:false })
db.Respuestas.insertOne({ Identificador: 4, Descripcion: "2", RespuestaCorrecta:true })
db.Respuestas.insertOne({ Identificador: 5, Descripcion: "3", RespuestaCorrecta:false })
db.Respuestas.insertOne({ Identificador: 6, Descripcion: "4", RespuestaCorrecta:true })
db.Respuestas.insertOne({ Identificador: 7, Descripcion: "5", RespuestaCorrecta:false })
db.Respuestas.insertOne({ Identificador: 8, Descripcion: "6", RespuestaCorrecta:true })


db.PreguntasRespuestas.insertOne({ Pregunta_Id: 1, Respuesta_Id: 1 })
db.PreguntasRespuestas.insertOne({ Pregunta_Id: 1, Respuesta_Id: 2 })
db.PreguntasRespuestas.insertOne({ Pregunta_Id: 2, Respuesta_Id: 3 })
db.PreguntasRespuestas.insertOne({ Pregunta_Id: 2, Respuesta_Id: 4 })
db.PreguntasRespuestas.insertOne({ Pregunta_Id: 2, Respuesta_Id: 5 })
db.PreguntasRespuestas.insertOne({ Pregunta_Id: 2, Respuesta_Id: 6 })
db.PreguntasRespuestas.insertOne({ Pregunta_Id: 2, Respuesta_Id: 7 })
db.PreguntasRespuestas.insertOne({ Pregunta_Id: 2, Respuesta_Id: 8 })

