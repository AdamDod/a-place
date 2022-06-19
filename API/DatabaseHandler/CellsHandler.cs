using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using API.Models;
using Microsoft.AspNetCore.SignalR;

namespace API
{
    public class CellsHandler : DatabaseHandler
    {

        public List<Cell> GetCells()
        {
            List<Cell> Cells = new List<Cell>();

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM CELLS", conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cells.Add(new Cell()
                            {
                                CellID = reader.GetInt32(0),
                                Colour = reader.GetString(1),
                            });
                        }
                    }
                }
                conn.Close();
            }
            if (Cells == null) return null;

            return Cells;
        }

        public String ChangeCell(Cell cell,IHubContext<CellHub> _hub)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("CHANGE_CELL", conn))
                {
                    Console.WriteLine(cell.Colour);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pCellID", cell.CellID);
                    command.Parameters.AddWithValue("@pColour", cell.Colour);
                    rowsAffected += command.ExecuteNonQuery();
                }
            
                conn.Close();
            }
            if (rowsAffected > 0)
            {
                _hub.Clients.All.SendAsync("update", cell);
                return "Cell Updated";
            }
            else
            {
                return "Cell Not Updated";
            }

        }


    }
}