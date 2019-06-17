$address = "studmysql01.fhict.local"
$dbusername = "dbi385070";
$dbpassword = "GENK";
$db_name = "dbi385070";
$db_conn = new mysqli($address, $dbusername, $dbpassword, $db_name);
    
$stmt = $db_conn->prepare("SELECT * FROM scores");
if($stmt->execute())
{
    $stmt->bind_result($name, $score);
    $stmt->fetch();
}
else
{
    echo "query failed";
}
$stmt->close();
$db_conn->close();