🧬 ¿Qué hace este programa?
Este programa analiza secuencias de ADN para identificar y contar las proteínas (nucleótidos) que las componen.
________________________________________
📋 Funcionalidad Principal:
1. Entrada de Datos
•	El usuario debe ingresar 20 valores (uno por uno en cada casilla)
•	Solo acepta las letras: A, C, G, T (mayúsculas o minúsculas) 
o	A = Adenina
o	C = Citosina
o	G = Guanina
o	T = Timina
2. Validación
•	Verifica que todos los 20 campos estén llenos
•	Identifica si hay valores incorrectos (cualquier letra diferente a A, C, G, T)
3. Análisis Visual con Colores
Cuando presionas "Analizar", cada casilla se colorea según el tipo:
•	🟢 Verde claro → Adenina (A)
•	🔵 Azul claro → Citosina (C)
•	🟠 Naranja claro → Guanina (G)
•	🌸 Rosa claro → Timina (T)
•	🔴 Rojo → Dato erróneo
4. Resultados
Si TODOS los valores son correctos (A, C, G, T):
Muestra un reporte completo con:
•	Cantidad de cada proteína encontrada
•	Porcentaje que representa del total
•	Ejemplo:
✓ SECUENCIA VÁLIDA - ANÁLISIS COMPLETADO

(A)denina  :  5 proteínas -  25.0%
(C)itosina :  7 proteínas -  35.0%
(G)uanina  :  4 proteínas -  20.0%
(T)imina   :  4 proteínas -  20.0%
───────────────────────────────
TOTAL      : 20 proteínas - 100.0%
Si HAY datos erróneos (X, Z, 1, etc.):
Muestra solo:
⚠️  ATENCIÓN  ⚠️

Se encontraron 3 dato(s) erróneo(s)

La secuencia NO es válida para análisis.
5. Botón Limpiar
•	Borra todos los campos
•	Quita los colores
•	Reinicia el formulario para un nuevo análisis
________________________________________
🎯 Ejemplo de Uso:
Usuario ingresa: A, T, G, C, A, T, G, C, A, T, G, C, A, T, G, C, A, T, G, C
Resultado:
•	✅ Secuencia válida
•	5 Adeninas (25%)
•	5 Timinas (25%)
•	5 Guaninas (25%)
•	5 Citosinas (25%)
________________________________________
💡 Propósito del Programa:
Simula el trabajo de un laboratorio de genética que necesita:
1.	Verificar que las muestras de ADN sean válidas
2.	Contar las proteínas de cada tipo
3.	Calcular su distribución porcentual
4.	Identificar errores en las muestras
