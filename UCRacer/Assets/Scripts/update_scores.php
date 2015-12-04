<?
// CONNECTIONS =========================================================
$host = "mysql14.000webhost.com"; //put your host here
$user = "a7031497_cs180"; //in general is root
$password = "cs180ucr"; //use your password here
$dbname = "a7031497_hiscore"; //your database
mysql_connect($host, $user, $password) or die("Cant connect into database");
mysql_select_db($dbname)or die("Cant connect into database");
// =============================================================================
// PROTECT AGAINST SQL INJECTION and CONVERT PASSWORD INTO MD5 formats
function anti_injection_login_senha($sql, $formUse = true)
{
$sql = preg_replace("/(from|select|insert|delete|where|drop table|show tables|,|'|#|\*|--|\\\\)/i","",$sql);
$sql = trim($sql);
$sql = strip_tags($sql);
if(!$formUse || !get_magic_quotes_gpc())
  $sql = addslashes($sql);
  $sql = md5(trim($sql));
return $sql;
}
// THIS ONE IS JUST FOR THE NICKNAME PROTECTION AGAINST SQL INJECTION
function anti_injection_login($sql, $formUse = true)
{
$sql = preg_replace("/(from|select|insert|delete|where|drop table|show tables|,|'|#|\*|--|\\\\)/i","",$sql);
$sql = trim($sql);
$sql = strip_tags($sql);
if(!$formUse || !get_magic_quotes_gpc())
  $sql = addslashes($sql);
return $sql;
}
// =============================================================================
$unityHash = anti_injection_login($_POST["myform_hash"]);
$phpHash = "736868697473736563726574"; // same code in here as in your Unity game
 
$nick = anti_injection_login($_POST["myform_nick"]); //I use that function to protect against SQL injection
//$pass = anti_injection_login_senha($_POST["myform_pass"]); //THIS IS SO BAD NEVER EVER DO THIS
$tracknum = anti_injection_login($_POST["myform_tracknum"]); // where $tracknum = "hiscore", "hiscore2", or "hiscore3"
$hiscore_string = anti_injection_login($_POST["myform_hiscore"]);
$hiscore = (float) $hiscore_string;
 // mysql TIME format: HH:MM:SS. floating points allowed?
/*
you can also use this:
$nick = $_POST["myform_nick"];
$pass = $_POST["myform_pass"];
*/
if ($unityHash != $phpHash){
	echo "HASH code is diferent from your game, you infidel.";
} else {
	// $SQL = "SELECT * FROM scores WHERE name = '" . $nick . "'";
	//$SQL = "INSERT INTO scores ( id , name , password ) VALUES (NULL, '" . $nick . "', '" . $pass . "' )";
	$SQL = "SELECT " . $nick . " FROM scores";
	$result_id = @mysql_query($SQL) or die("DATABASE ERROR!" . mySQL_error());
	$total = mysql_num_rows($result_id);
	if($total)
	{
		$datas = @mysql_fetch_array($result_id);
		if($hiscore < $datas[$tracknum]) // I really hope the anti_injection_login doesn't fuck with this
		{
			$SQL = "UPDATE scores SET " . $tracknum . "='" . $hiscore . "' WHERE name = '" . $nick . "'";
			$result_id = @mysql_query($SQL) or die("DATABASE ERROR!" . mySQL_error());
			if ($result_id)
			{
				echo "Success! Hiscore updated";
			}
			else // update failed
			{
				echo 'Insert failed: ' . mySQL_error();
			}
		}
		else
		{
			echo 'hiscore rejected n00b';
		}
	}
	
	// $total = mysql_num_rows($result_id);
	// if($total) {
		// $datas = @mysql_fetch_array($result_id);
		// if(!strcmp($pass, $datas["password"])) {
			// echo "LOGADO - PASSWORD CORRECT";
		// } else {
			// echo "Nick or password is wrong.";
		// }
	// } else {
		// echo "Data invalid - cant find name.";
	// }
}
// Close mySQL Connection
mysql_close();
?>