using Microsoft.EntityFrameworkCore;
using Registro.DAL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Registro.BLL {
    public class InscripcionesBLL {

        public static bool Guardar(Inscripcion inscripcion) {

            bool guardado = false;
            Contexto db = new Contexto();

			try {

                if (db.Add(inscripcion) != null) {
                    guardado = (db.SaveChanges() > 0);
                }

			} catch (Exception) {

				throw;

            } finally {
                db.Dispose();
            }

            return guardado;

        }

        public static bool Modificar(Inscripcion inscripcion) {

            bool modificado = false;
            Contexto db = new Contexto();

            try {

                db.Entry(inscripcion).State = EntityState.Modified;
                modificado = (db.SaveChanges() > 0);

            } catch (Exception) {

                throw;

            } finally {

                db.Dispose();
            }

            return modificado;

        }

        public static void Eliminar(int id) {

            bool eliminado = false;
            Contexto db = new Contexto();

            try {

                var inscripcionEliminada = db.Inscripciones.Find(id);
                db.Entry(inscripcionEliminada).State = EntityState.Deleted;

                eliminado = (db.SaveChanges() > 0);

            } catch (Exception) {

                throw;

            } finally {

                db.Dispose();
            }

        }

        public static Inscripcion Buscar(int id) {

            Inscripcion inscripcion = new Inscripcion();
            Contexto db = new Contexto();

            try {

                inscripcion = db.Inscripciones.Find(id);

            } catch (Exception) {

                throw;

            } finally {

                db.Dispose();
            }

            return inscripcion;
        }

        public static List<Inscripcion> GetList(Expression<Func<Inscripcion, bool>> expression) {

            List<Inscripcion> inscripcionesList = new List<Inscripcion>();
            Contexto db = new Contexto();

            try {

                inscripcionesList = db.Inscripciones.Where(expression).ToList();
                                                                               
            } catch (Exception) {

                throw;

            } finally {

                db.Dispose();
            }

            return inscripcionesList;

        }

    }
}
