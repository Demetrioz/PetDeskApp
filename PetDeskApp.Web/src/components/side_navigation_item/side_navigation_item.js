import { useNavigate } from 'react-router-dom';
import { ListItem, ListItemButton, ListItemText } from '@mui/material';

export default function SideNavigationItem(props) {
  const navigate = useNavigate();

  const handleNavigation = () => {
    navigate(props.destination);
  };

  return (
    <ListItem disablePadding>
      <ListItemButton onClick={handleNavigation}>
        <ListItemText>{props.text}</ListItemText>
      </ListItemButton>
    </ListItem>
  );
}
