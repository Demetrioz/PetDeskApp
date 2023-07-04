import { AppBar, Toolbar, Typography } from '@mui/material';
import Box from '@mui/material/Box';

export default function Header() {
  return (
    <Box sx={{ display: 'flex' }}>
      <AppBar
        position='fixed'
        sx={{ zIndex: (theme) => theme.zIndex.drawer + 1 }}
      >
        <Toolbar>
          <Typography variant='h6' noWrap component='div'>
            PetDesk App
          </Typography>
        </Toolbar>
      </AppBar>
    </Box>
  );
}
