import { Group } from "@mui/icons-material";
import { Box, AppBar, Toolbar, Typography, Container, MenuItem, Button } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { jwtDecode } from "jwt-decode";
import '../../css/NaveBar.css';



export default function NaveBar() {
  const token = localStorage.getItem("token");
  const role = localStorage.getItem("role")?.trim().toLowerCase();
  const navigate = useNavigate();
  

  let fullName = "";

 if (token) {
    try {
      const decoded: any = jwtDecode(token);

      const firstName = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname"];
      const lastName = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname"];

      fullName = `${firstName} ${lastName}`;
    } catch (error) {
      console.error("Token decoding failed:", error);
    }
  }

  const handleLogout = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("role");
    navigate("/");
  };

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar
        position="static"
        sx={{
          backgroundImage: 'linear-gradient(135deg, #182a73 0%, #218aae 69%, #20a7ac 89%)',
        }}
      >
        <Container maxWidth="xl">
          <Toolbar sx={{ display: "flex", justifyContent: "space-between" }}>
            <Box>
              <MenuItem sx={{ display: "flex", gap: 2 }} onClick={() => navigate("/home")}>
                <Group fontSize="large" />
                <Typography variant="h4" fontWeight="bold">
                  DFly
                </Typography>
              </MenuItem>
            </Box>

            <Box sx={{ display: "flex", alignItems: "center", gap: 3 }}>
              {role === "user" && <MenuItem onClick={() => navigate("/flights")}>Zboruri disponibile</MenuItem>}
              {role === "user" && <MenuItem onClick={()=> navigate("/create-ticket")}>Rezerveaza Bilet</MenuItem>}
              {role === "user" && <MenuItem onClick={()=> navigate("/reserved-tickets")}>Biletele rezervate</MenuItem>}


              {role === "admin" && <MenuItem onClick={()=> navigate("/send-message")}>Trimte Notificari</MenuItem>}
              {role === "admin" && <MenuItem onClick={()=> navigate("/create-flight")}>Creaza Zbor</MenuItem>}

              {role === "worker" && <MenuItem onClick={() =>navigate("/verify-checkins")}>Verify checkin</MenuItem>}
              {role === "worker" && <MenuItem onClick={() => navigate("/flights")}>Zboruri disponibile</MenuItem>}
              {role === "worker" && <MenuItem onClick={() => navigate("/update-status")}>Update Flight status</MenuItem>}
              {role === "worker" && <MenuItem onClick={()=> navigate("/send-message")}>Trimte Notificari</MenuItem>}

              <Typography className="navbar-user">
                  {fullName}
              </Typography>

              <Button
                onClick={handleLogout}
                className="logout-button"
              >
                Logout
              </Button>
            </Box>
          </Toolbar>
        </Container>
      </AppBar>
    </Box>
  );
}
