using Microsoft.EntityFrameworkCore;
using Registro.DAL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Registro.BLL {
	public class PersonasBLL {

		public static void ActualizarBalance(int personaId) {

			decimal nuevoBalance = 0.0m;

			Persona persona = Buscar(personaId);

			List<Inscripcion> inscripcionesList = InscripcionesBLL.GetList(i => i.PersonaId == personaId);

			foreach (Inscripcion i in inscripcionesList) {
				nuevoBalance += i.Balance;
			}

			persona.Balance = nuevoBalance;

			Modificar(persona);

		}

		public static bool Guardar(Persona persona) {

			bool guardado = false;
			Contexto db = new Contexto();

			try {

				if (db.Add(persona) != null) {
					guardado = (db.SaveChanges() > 0);
				}

			} catch (Exception) {

				throw;

			} finally {

				db.Dispose();//Esta función cierra la conexión con la base de datos

			}

			return guardado;

		}

		public static bool Modificar(Persona persona) {

			bool modificado = false;
			Contexto db = new Contexto();

			try {

				db.Entry(persona).State = EntityState.Modified;
				modificado = (db.SaveChanges() > 0);

			} catch (Exception) {

				throw;

			} finally {

				db.Dispose();

			}

			return modificado;

		}

		public static bool Eliminar(int id) {

			bool eliminado = false;
			Contexto db = new Contexto();

			try {

				var eliminar = db.Personas.Find(id);
				db.Entry(eliminar).State = EntityState.Deleted;

				eliminado = (db.SaveChanges() > 0);

			} catch (Exception) {

				throw;

			} finally {

				db.Dispose();

			}

			return eliminado;

		}

		public static Persona Buscar(int id) {

			Persona persona = new Persona();
			Contexto db = new Contexto();

			try {

				persona = db.Personas.Find(id);

			} catch (Exception) {

				throw;

			} finally {

				db.Dispose();

			}

			return persona;

		}

		public static List<Persona> GetList(Expression<Func<Persona , bool>> persona) {

			List<Persona> personasList = new List<Persona>();
			Contexto db = new Contexto();

			try {

				personasList = db.Personas.Where(persona).ToList();

			} catch (Exception) {

				throw;

			} finally {

				db.Dispose();

			}

			return personasList;

		}


	}
}
