const express = require('express');
const mysql = require('mysql2');
const app = express();
const port = 3000;

// Crear conexión a la base de datos
const db = mysql.createConnection({
    host: 'localhost',  // Cambia esto según tu configuración
    user: 'root',       // Usuario de la base de datos
    password: '',       // Contraseña de la base de datos
    database: 'festival_db' // Nombre de la base de datos
});

// Verificar la conexión
db.connect(err => {
    if (err) {
        console.error('Error de conexión a la base de datos: ' + err.stack);
        return;
    }
    console.log('Conectado a la base de datos');
});

// Ruta para obtener los lugares
app.get('/api/lugares', (req, res) => {
    const query = 'SELECT * FROM lugares'; // Suponiendo que tienes una tabla llamada 'lugares'
    db.query(query, (err, results) => {
        if (err) {
            console.error('Error en la consulta: ' + err.stack);
            return res.status(500).json({ error: 'Error en la consulta' });
        }
        res.json(results);
    });
});

// Iniciar el servidor
app.listen(port, () => {
    console.log(`Servidor corriendo en http://localhost:${port}`);
});
