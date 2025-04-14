// App.js
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './App.css';

function App() {
  const [appointments, setAppointments] = useState([]);
  const [appointmentServices, setAppointmentServices] = useState([]);
  const [diagnoses, setDiagnoses] = useState([]);
  const [employees, setEmployees] = useState([]);
  const [medications, setMedications] = useState([]);
  const [patients, setPatients] = useState([]);
  const [prescriptions, setPrescriptions] = useState([]);
  const [services, setServices] = useState([]);

  const [showModal, setShowModal] = useState(false);
  const [modalMode, setModalMode] = useState('edit');
  const [currentRecord, setCurrentRecord] = useState(null);
  const [currentEndpoint, setCurrentEndpoint] = useState('');
  const [refresh, setRefresh] = useState(false);


  const [filterAppointmentId, setFilterAppointmentId] = useState('');

  const [filterPatientId, setFilterPatientId] = useState('');
  const [filterEmployeeId, setFilterEmployeeId] = useState('');

  const [filterASAppointmentId, setFilterASAppointmentId] = useState('');
  const [filterASServiceId, setFilterASServiceId] = useState('');

  const [filterPrescDiagnosisId, setFilterPrescDiagnosisId] = useState('');
  const [filterPrescMedicationId, setFilterPrescMedicationId] = useState('');

  useEffect(() => {
    axios.get('/api/appointments')
      .then(response => setAppointments(response.data))
      .catch(err => console.error('Ошибка appointments: ', err));

    axios.get('/api/appointmentservices')
      .then(response => setAppointmentServices(response.data))
      .catch(err => console.error('Ошибка appointmentervices: ', err));

    axios.get('/api/diagnoses')
      .then(response => setDiagnoses(response.data))
      .catch(err => console.error('Ошибка diagnoses: ', err));

    axios.get('/api/employees')
      .then(response => setEmployees(response.data))
      .catch(err => console.error('Ошибка employees: ', err));

    axios.get('/api/medications')
      .then(response => setMedications(response.data))
      .catch(err => console.error('Ошибка medications: ', err));

    axios.get('/api/patients')
      .then(response => setPatients(response.data))
      .catch(err => console.error('Ошибка patients: ', err));

    axios.get('/api/prescriptions')
      .then(response => setPrescriptions(response.data))
      .catch(err => console.error('Ошибка prescriptions: ', err));

    axios.get('/api/services')
      .then(response => setServices(response.data))
      .catch(err => console.error('Ошибка services: ', err));
  }, [refresh]);

  const handleFilterDiagnoses = () => {
    if (filterAppointmentId) {
      axios.get(`/api/diagnoses/byAppointment/${filterAppointmentId}`)
        .then(response => setDiagnoses(response.data))
        .catch(err => {
          console.error('Ошибка при фильтрации диагнозов: ', err);
          alert('Ошибка при фильтрации диагнозов');
        });
    }
  };

  const handleFilterByPatient = () => {
    if (filterPatientId) {
      axios.get(`/api/appointments/byPatient/${filterPatientId}`)
        .then(response => setAppointments(response.data))
        .catch(err => {
          console.error('Ошибка при фильтрации по Patient: ', err);
          alert('Ошибка при фильтрации по Patient');
        });
    }
  };

  const handleFilterByEmployee = () => {
    if (filterEmployeeId) {
      axios.get(`/api/appointments/byEmployee/${filterEmployeeId}`)
        .then(response => setAppointments(response.data))
        .catch(err => {
          console.error('Ошибка при фильтрации по Employee: ', err);
          alert('Ошибка при фильтрации по Employee');
        });
    }
  };

  const resetFilterAppointments = () => {
    setFilterPatientId('');
    setFilterEmployeeId('');
    axios.get('/api/appointments')
      .then(response => setAppointments(response.data))
      .catch(err => console.error('Ошибка appointments: ', err));
  };

  const resetFilterDiagnoses = () => {
    setFilterAppointmentId('');
    axios.get('/api/diagnoses')
      .then(response => setDiagnoses(response.data))
      .catch(err => console.error('Ошибка diagnoses: ', err));
  };

    const handleFilterASByAppointment = () => {
      if (filterASAppointmentId) {
        axios.get(`/api/appointmentervices/byAppointment/${filterASAppointmentId}`)
          .then(response => setAppointmentServices(response.data))
          .catch(err => {
            console.error('Ошибка при фильтрации Appointment Services по Appointment: ', err);
            alert('Ошибка при фильтрации по Appointment');
          });
      }
    };
  
    const handleFilterASByService = () => {
      if (filterASServiceId) {
        axios.get(`/api/appointmentervices/byService/${filterASServiceId}`)
          .then(response => setAppointmentServices(response.data))
          .catch(err => {
            console.error('Ошибка при фильтрации Appointment Services по Service: ', err);
            alert('Ошибка при фильтрации по Service');
          });
      }
    };
  
    const resetFilterAppointmentServices = () => {
      setFilterASAppointmentId('');
      setFilterASServiceId('');
      axios.get('/api/appointmentervices')
        .then(response => setAppointmentServices(response.data))
        .catch(err => console.error('Ошибка appointmentervices: ', err));
    };

  const handleEdit = (record, endpoint) => {
    setCurrentRecord(record);
    setCurrentEndpoint(endpoint);
    setModalMode("edit");
    setShowModal(true);
  };

  const handleAdd = (endpoint, emptyRecord) => {
    setCurrentRecord(emptyRecord);
    setCurrentEndpoint(endpoint);
    setModalMode("add");
    setShowModal(true);
  };

  const handleDelete = (record, endpoint, idField) => {
    const id = record[idField];
    if (window.confirm('Вы уверены, что хотите удалить эту запись?')) {
      axios.delete(`${endpoint}/${id}`)
        .then(response => {
          alert("Запись удалена!");
          setRefresh(prev => !prev);
        })
        .catch(error => {
          console.error('Ошибка при удалении записи:', error);
          alert("Ошибка при удалении записи");
        });
    }
  };

  const handleFilterPrescByDiagnosis = () => {
    if (filterPrescDiagnosisId) {
      axios.get(`/api/prescriptions/byDiagnosis/${filterPrescDiagnosisId}`)
        .then(response => setPrescriptions(response.data))
        .catch(err => {
          console.error('Ошибка при фильтрации Prescriptions по Diagnosis: ', err);
          alert('Ошибка при фильтрации по Diagnosis');
        });
    }
  };

  const handleFilterPrescByMedication = () => {
    if (filterPrescMedicationId) {
      axios.get(`/api/prescriptions/byMedication/${filterPrescMedicationId}`)
        .then(response => setPrescriptions(response.data))
        .catch(err => {
          console.error('Ошибка при фильтрации Prescriptions по Medication: ', err);
          alert('Ошибка при фильтрации по Medication');
        });
    }
  };

  const resetFilterPrescriptions = () => {
    setFilterPrescDiagnosisId('');
    setFilterPrescMedicationId('');
    axios.get('/api/prescriptions')
      .then(response => setPrescriptions(response.data))
      .catch(err => console.error('Ошибка prescriptions: ', err));
  };

  const handleModalClose = () => {
    setShowModal(false);
    setCurrentRecord(null);
    setCurrentEndpoint('');
  };

  const handleInputChange = (e) => {
    setCurrentRecord({
      ...currentRecord,
      [e.target.name]: e.target.value
    });
  };

  const handleSave = () => {
    if (modalMode === "edit") {
      console.log(currentRecord)
      axios.put(`${currentEndpoint}/${currentRecord[getIdField(currentEndpoint)]}`, currentRecord)
        .then(response => {
          alert("Запись обновлена!");
          setShowModal(false);
          setRefresh(prev => !prev);
        })
        .catch(error => {
          console.error('Ошибка при обновлении записи:', error);
          alert("Ошибка при обновлении записи");
        });
    } else {
      axios.post(currentEndpoint, currentRecord)
        .then(response => {
          alert("Запись добавлена!");
          setShowModal(false);
          setRefresh(prev => !prev);
        })
        .catch(error => {
          console.error('Ошибка при добавлении записи:', error);
          alert("Ошибка при добавлении записи");
        });
    }
  };

  const getIdField = (endpoint) => {
    if (endpoint === `/api/patients`) return `patientId`
    else if (endpoint === `/api/employees`) return `employeeId`
    else if (endpoint === `/api/services`) return `serviceId`
    else if (endpoint === `/api/appointments`) return `appointmentId`
    else if (endpoint === `/api/appointmentservices`) return `appointmentServiceId`
    else if (endpoint === `/api/prescriptions`) return `prescriptionId`
    else if (endpoint === `/api/medications`) return `medicationId`
    else if (endpoint === `/api/diagnoses`) return `diagnosisId`
  };

  const renderTable = (data, endpoint, keys, idField) => {
    return (
      <div className="table-container">
        <button 
          onClick={() => handleAdd(endpoint, keys.reduce((acc, key) => {
            if(key === idField) return acc;
            return { ...acc, [key]: "" };
          }, {}))}
        >
          Add New
        </button>
        <table className="data-table">
          <thead>
            <tr>
              <th>{idField}</th>
              {keys.filter(key => key !== idField).map(key => (
                <th key={key}>{key}</th>
              ))}
              <th>Действия</th>
            </tr>
          </thead>
          <tbody>
            {data.map(item => (
              <tr key={item[idField]}>
                <td>{item[idField]}</td>
                {keys.filter(key => key !== idField).map(key => (
                  <td key={key}>{item[key]}</td>
                ))}
                <td>
                  <button onClick={() => handleEdit(item, endpoint)}>Edit</button>
                  <button onClick={() => handleDelete(item, endpoint, idField)}>Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  };

  return (
    <div className="App">
      <h1>Главная страница</h1>

      <section>
        <h2>Appointments</h2>
        <div className="filter-container">
          <input 
            type="text" 
            placeholder="Введите patientId" 
            value={filterPatientId}
            onChange={(e) => setFilterPatientId(e.target.value)}
          />
          <button onClick={handleFilterByPatient}>Filter by Patient</button>
          <input 
            type="text" 
            placeholder="Введите employeeId" 
            value={filterEmployeeId}
            onChange={(e) => setFilterEmployeeId(e.target.value)}
          />
          <button onClick={handleFilterByEmployee}>Filter by Employee</button>
          <button onClick={resetFilterAppointments}>Reset</button>
        </div>
        {renderTable(appointments, '/api/appointments', ['status', 'appointmentDate', 'notes', 'patientId', 'employeeId'], 'appointmentId')}
      </section>

      <section>
        <h2>Appointment Services</h2>
        <div className="filter-container">
          <input 
            type="text" 
            placeholder="Введите appointmentId" 
            value={filterASAppointmentId}
            onChange={(e) => setFilterASAppointmentId(e.target.value)}
          />
          <button onClick={handleFilterASByAppointment}>Filter by Appointment</button>
          <input 
            type="text" 
            placeholder="Введите serviceId" 
            value={filterASServiceId}
            onChange={(e) => setFilterASServiceId(e.target.value)}
          />
          <button onClick={handleFilterASByService}>Filter by Service</button>
          <button onClick={resetFilterAppointmentServices}>Reset</button>
        </div>
        {renderTable(appointmentServices, '/api/appointmentservices', ['result', 'appointmentId', 'serviceId'], 'appointmentServiceId')}
      </section>

      <section>
        <h2>Diagnoses</h2>
        <div className="filter-container">
          <input 
            type="text" 
            placeholder="Введите appointmentId для фильтра" 
            value={filterAppointmentId}
            onChange={(e) => setFilterAppointmentId(e.target.value)}
          />
          <button onClick={handleFilterDiagnoses}>Filter</button>
          <button onClick={resetFilterDiagnoses}>Reset</button>
        </div>
        {renderTable(diagnoses, '/api/diagnoses', ['diagnosisCode', 'description', 'recommendations', 'appointmentId'], 'diagnosisId')}
      </section>

      <section>
        <h2>Employees</h2>
        {renderTable(employees, '/api/employees', ['fullName', 'specialization', 'licenseNumber', 'phone'], 'employeeId')}
      </section>

      <section>
        <h2>Medications</h2>
        {renderTable(medications, '/api/medications', ['name', 'manufacturer', 'price'], 'medicationId')}
      </section>

      <section>
        <h2>Patients</h2>
        {renderTable(patients, '/api/patients', ['fullName', 'birthDate', 'gender', 'passportNumber', 'phone', 'email', 'address'], 'patientId')}
      </section>

      <section>
        <h2>Prescriptions</h2>
        <div className="filter-container">
          <input 
            type="text" 
            placeholder="Введите diagnosisId" 
            value={filterPrescDiagnosisId}
            onChange={(e) => setFilterPrescDiagnosisId(e.target.value)}
          />
          <button onClick={handleFilterPrescByDiagnosis}>Filter by Diagnosis</button>
          <input 
            type="text" 
            placeholder="Введите medicationId" 
            value={filterPrescMedicationId}
            onChange={(e) => setFilterPrescMedicationId(e.target.value)}
          />
          <button onClick={handleFilterPrescByMedication}>Filter by Medication</button>
          <button onClick={resetFilterPrescriptions}>Reset</button>
        </div>
        {renderTable(prescriptions, '/api/prescriptions', ['dosage', 'durationDays', 'diagnosisId', 'medicationId'], 'prescriptionId')}
      </section>

      <section>
        <h2>Services</h2>
        {renderTable(services, '/api/services', ['name', 'price', 'durationMinutes'], 'serviceId')}
      </section>

      {showModal && currentRecord && (
        <div className="modal-overlay">
          <div className="modal-content">
            <h2>{modalMode === "edit" ? "Редактирование записи" : "Добавление записи"}</h2>
            {Object.keys(currentRecord).map((key) => (
              <div key={key} className="form-group">
                <label>{key}</label>
                <input
                  type={ key === 'birthDate' ? 'date' : 'text' }
                  name={key}
                  value={
                    key === 'birthDate'
                      ? currentRecord[key] ? currentRecord[key].substring(0,10) : ''
                      : currentRecord[key]
                  }
                  onChange={handleInputChange}
                  readOnly={key === getIdField(currentEndpoint)}
                />
              </div>
            ))}
            <div className="modal-actions">
              <button onClick={handleSave}>Сохранить</button>
              <button onClick={handleModalClose}>Отмена</button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}

export default App;
