export default function LogInModal() {
    return (
            <div className="modal fade" id="logInModal" tabIndex="-1" aria-labelledby="logInModalLabel" aria-hidden="true">
                <div className="modal-dialog">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h5 className="modal-title" id="logInModalLabel">Zaloguj się</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div className="modal-body">
                            <form>
                                <div className="mb-3">
                                    <label htmlFor="login" className="col-form-label">Login:</label>
                                    <input type="text" className="form-control" id="login" />
                                </div>
                                <div className="mb-3">
                                    <label htmlFor="password" className="col-form-label">Hasło: </label>
                                    <input type="text" className="form-control" id="password" />
                                </div>
                            </form>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-primary" >Zaloguj</button>
                        </div>
                    </div>
                </div>
            </div>
    );
}