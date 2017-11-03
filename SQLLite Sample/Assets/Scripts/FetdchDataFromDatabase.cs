using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class FetdchDataFromDatabase : MonoBehaviour {

    public string conn;
    public IDbConnection dbconn;

    private void Start() {

        conn = "URI=file:" + Application.dataPath + "/SampleDatabase.s3db"; //Path to database
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        //string newQuery = "SELECT Name " + "FROM SampleTable";
        string sqlQuery = "SELECT Id,Name, Age " + "FROM SampleTable";
        //dbcmd.CommandText = newQuery;
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read()) {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            int age = reader.GetInt32(2);

            //string newValue = reader.GetString(1);

            Debug.Log("id= " + id + "  Name =" + name + "  Age =" + age);
            //Debug.Log(newValue);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        //dbconn.Close();
        //dbconn = null;
    }

	private void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			DisplaySomething ();
		}
	}

	public void DisplaySomething(){
		string sqlQuery = "SELECT Name " + "FROM SampleTable";
		IDbCommand dbcmd = dbconn.CreateCommand();
		IDataReader reader = dbcmd.ExecuteReader();
		while (reader.Read()) {			
			string name = reader.GetString(1);
			Debug.Log("Name =" + name);
		}
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
	}
}
