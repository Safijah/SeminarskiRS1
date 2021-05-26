
import axios from 'axios';
import { useEffect, useState } from 'react';
import Button from '@material-ui/core/Button';

import './Kuhari.css';
import { withStyles, makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

const StyledTableCell = withStyles((theme) => ({
  head: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  body: {
    fontSize: 14,
  },
}))(TableCell);

const StyledTableRow = withStyles((theme) => ({
  root: {
    '&:nth-of-type(odd)': {
      backgroundColor: theme.palette.action.hover,
    },
  },
}))(TableRow);


const useStyles = makeStyles({
  table: {
    minWidth: 700,
  },
});






function Kuhari() {
  const classes = useStyles();

  const [Kuhari,SetKuhari]=useState({data: []});
  useEffect(()=>{
    axios.get("https://localhost:44367/KuharApi").then(result=>(
    SetKuhari({data:result.data})
    ))
  },[]);
  return (
    <div>
      <br/>
      <Button variant="outlined">Dodaj novog</Button>
      <br/>
      <br/>

    <TableContainer component={Paper}>
      <Table className={classes.table} aria-label="customized table">
        <TableHead>
          <TableRow>
            <StyledTableCell>Ime</StyledTableCell>
            <StyledTableCell align="right">Prezime</StyledTableCell>
            <StyledTableCell align="right">Plata</StyledTableCell>
            <StyledTableCell align="right">Akcija</StyledTableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {Kuhari.data.map((row) => (
            <StyledTableRow key={row.kuharID}>
              <StyledTableCell component="th" scope="row">
                {row.imeKuhara}
              </StyledTableCell>
              <StyledTableCell align="right">{row.prezimeKuhara}</StyledTableCell>
              <StyledTableCell align="right">{row.plataKuhara}</StyledTableCell>
              <StyledTableCell align="right"><Button variant="outlined">Uredi</Button>
</StyledTableCell>
            </StyledTableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
    </div>
  );
}

export default Kuhari;
